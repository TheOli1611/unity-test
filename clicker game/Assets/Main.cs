using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Main : MonoBehaviour
{
    [Header("General")]
    public static Double CDCount;
    public TextMeshProUGUI CDCountText;
    public GameObject upgradeShopUI;
    public Boolean upgradeShopOpened = false;
    [Header("Menu")]
    public static Double CDCountOverall;
    public TextMeshProUGUI CDCountOverallText;
    public GameObject menuUI;
    [Header("Shaker Upgrade")]
    public int basePrice1 = 20;
    public Double requiredAmount1;
    public int timesUpgraded1 = 0;
    public Button upgradeButton1;
    public TextMeshProUGUI priceText1;
    public TextMeshProUGUI timesUpgradedText1;
    [Header("Cloud Helpers Upgrade")]
    public int basePrice2 = 50;
    public Double requiredAmount2;
    public int timesUpgraded2 = 0;
    public Button upgradeButton2;
    public TextMeshProUGUI priceText2;
    public TextMeshProUGUI timesUpgradedText2;
    public float pointTimer;
    public float pointSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        CDCount = 0;
        upgradeButton1.interactable = false;
        UpdatePriceText();

        requiredAmount1 = basePrice1;
        requiredAmount2 = basePrice2;

        pointTimer = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (CDCount >= requiredAmount1)
        {
            upgradeButton1.interactable = true;
        }
        else
        {
            upgradeButton1.interactable = false;
        }

        if (CDCount >= requiredAmount2)
        {
            upgradeButton2.interactable = true;
        }
        else
        {
            upgradeButton2.interactable = false;
        }

        if (timesUpgraded2 > 0 && Time.fixedTime - pointTimer >= pointSpeed)
        {
            CDCount += 1 + timesUpgraded2 - 1;
            UpdateCDCountText();
            pointTimer = Time.fixedTime;
        }

    }

    /** GENERAL
        This contains:
        - Adding CD
        - Updating CD Text
        - Opening shop UI

    **/

    //adds CD with every click and updates the text
    public void AddCD()
    {
        CDCount = CDCount + 1 + timesUpgraded1;
        Debug.Log(CDCount);
        UpdateCDCountText();
    }
    //updates CD Count text
    public void UpdateCDCountText()
    {
        CDCountText.text = CDCount.ToString();
    }

    //opens and closes the shop UI
    public void UpgradeShopOpen()
    {
        if (upgradeShopOpened == false)
        {
            upgradeShopUI.SetActive(true);
            upgradeShopOpened = true;
        }
        else if (upgradeShopOpened == true)
        {
            upgradeShopUI.SetActive(false);
            upgradeShopOpened = false;
        }
    }

    /** MENU
        This contains:
        - Showcasing the highest CD count
        - Updating overall CD count text
    **/

    /** SHAKER UPGRADE
        This contains:
        - Updating shaker price
        - Buying upgrade with CD
        - Keeping track of number of times upgraded
        - Updates text
    **/

    //the first shop upgrade. Lets you buy the upgrade and makes the price higher
    public void Upgrade1()
    {
        if (CDCount >= requiredAmount1)
        {
            CDCount = CDCount - requiredAmount1;
            Debug.Log("New Total" + CDCount);
            timesUpgraded1 += 1;
            requiredAmount1 = Math.Round(basePrice1 * Math.Pow(2.5, timesUpgraded1));
            UpdatePriceText();
            UpdateTimesUpgradedText();
            UpdateCDCountText();
        }
    }

    //updates price text for upgrade 1
    public void UpdatePriceText()
    {
        priceText1.text = requiredAmount1.ToString() + " CD";
        priceText2.text = requiredAmount2.ToString() + " CD";
    }

    //updates times upgraded text for upgrade 1
    public void UpdateTimesUpgradedText()
    {
        timesUpgradedText1.text = timesUpgraded1.ToString();
        timesUpgradedText2.text = timesUpgraded2.ToString();
    }

    /** CLOUD HELPER UPGRADE
        This contains:
        - 
    **/

    public void Upgrade2()
    {
        if (CDCount >= requiredAmount2)
        {
            CDCount = CDCount - requiredAmount2;
            Debug.Log("New Total" + CDCount);
            timesUpgraded2 += 1;
            requiredAmount2 = Math.Round(basePrice2 * Math.Pow(1.5, timesUpgraded2));
            UpdatePriceText();
            UpdateTimesUpgradedText();
            UpdateCDCountText();
        }
    }

    IEnumerator AddCDPerSec()
    {
        WaitForSeconds delay = new WaitForSeconds(1);

        while (true)
        {
            CDCount += 1;
            yield return delay;
        }
    }

}
