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
    public static Double CDOverall = 0;
    public GameObject upgradeShopUI;
    public Boolean upgradeShopOpened = false;
    public GameObject arrow;
    public GameObject arrow2;
    public Boolean tutorialPlayed = false;
    public Boolean tutorialPlayed2 = false;
    public Shop shop;
    public AudioSource click;
    public AudioSource buy;
    public AudioSource mainMusic;
    [Header("Menu")]
    public GameObject menuUI;
    public Button menuButton;
    public Boolean menuOpened;
    [Header("Shaker Upgrade")]
    public int basePrice1 = 20;
    public Double requiredAmount1;
    public int timesUpgraded1 = 0;
    public int overallCount = 0;
    public Button upgradeButton1;
    public TextMeshProUGUI priceText1;
    public TextMeshProUGUI timesUpgradedText1;
    [Header("Cloud Helpers Upgrade")]
    public int basePrice2 = 50;
    public Double requiredAmount2;
    public int timesUpgraded2 = 0;
    public int overallCount2 = 0;
    public Button upgradeButton2;
    public TextMeshProUGUI priceText2;
    public TextMeshProUGUI timesUpgradedText2;
    public float pointTimer;
    public float pointSpeed = 1f;
    [Header("Water Upgrade")]
    public int basePrice3 = 500;
    public Double requiredAmount3;
    public Double upgradeMulti = 1;
    public int timesUpgraded3 = 0;
    public int overallCount3 = 0;
    public Button upgradeButton3;
    public TextMeshProUGUI priceText3;
    public TextMeshProUGUI timesUpgradedText3;


    [Header("Quest")]
    public int questAmount;


    // Start is called before the first frame update
    void Start()
    {
        CDCount = 0;
        upgradeButton1.interactable = false;
        upgradeButton2.interactable = false;
        upgradeButton3.interactable = false;
        UpdatePriceText();

        requiredAmount1 = basePrice1;
        requiredAmount2 = basePrice2;
        requiredAmount3 = basePrice3;

        pointTimer = Time.fixedTime;
        UpdatePriceText();
        mainMusic.Play();
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

        if (CDCount >= requiredAmount3)
        {
            upgradeButton3.interactable = true;
        }
        else
        {
            upgradeButton3.interactable = false;
        }

        if (overallCount2 > 0 && Time.fixedTime - pointTimer >= pointSpeed)
        {

            CDCount += Math.Round(10 * overallCount2 * upgradeMulti * shop.multiply);
            CDOverall += Math.Round(10 * overallCount2 * upgradeMulti * shop.multiply);

            UpdateCDCountText();
            pointTimer = Time.fixedTime;
        }

        /**while(tutorialPlayed == false) {
            if (CDCount >= 20)
            {
                arrow.SetActive(true);
                if (upgradeShopOpened == true)
                {
                    arrow.SetActive(false);
                    arrow2.SetActive(true);
                    if (shop.shopOpened == true)
                    {
                        Debug.Log("please work");
                        arrow2.SetActive(false);
                        tutorialPlayed = true;
                        tutorialPlayed2 = true;
                    }
                }
            }
        }
        **/
        if (tutorialPlayed == false && CDCount >= 20)
        {
            arrow.SetActive(true);
        }
        if (tutorialPlayed == false && timesUpgraded1 == 1)
        {
            arrow.SetActive(false);
            tutorialPlayed = true;
        }
        if (tutorialPlayed == true && tutorialPlayed2 == false)
        {
            arrow2.SetActive(true);
        }
        if (tutorialPlayed2 == false && shop.shopOpened == true)
        {
            arrow2.SetActive(false);
            tutorialPlayed2 = true;
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

        CDCount = CDCount + Math.Round((1 + overallCount) * upgradeMulti * shop.multiply);
        CDOverall = CDOverall + Math.Round((1 + overallCount) * upgradeMulti * shop.multiply);

        questAmount += 1;
        if (questAmount >= 500)
        {
            questAmount = 500;
        }
        Debug.Log(CDCount);
        UpdateCDCountText();
        click.time = 0.3f;
        click.Play();
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
        - Opening menu
    **/

    //opening menu
    public void MenuOpen()
    {
        menuUI.SetActive(true);

    }
    public void MenuClose()
    {
        menuUI.SetActive(false);
    }



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
            buy.Play();
            timesUpgraded1 += 1;
            overallCount += 1;
            requiredAmount1 = Math.Round(basePrice1 * Math.Pow(1.5, timesUpgraded1));
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
        priceText3.text = requiredAmount3.ToString() + " CD";
    }

    //updates times upgraded text for upgrade 1
    public void UpdateTimesUpgradedText()
    {
        timesUpgradedText1.text = overallCount.ToString();
        timesUpgradedText2.text = overallCount2.ToString();
        timesUpgradedText3.text = overallCount3.ToString();
    }

    /** CLOUD HELPER UPGRADE
        This contains:
        - Updating CLoud Helper price
        - Buying upgrade with CD
        - Keeping track of number of times upgraded
        - Updates Text
    **/

    public void Upgrade2()
    {
        if (CDCount >= requiredAmount2)
        {
            CDCount = CDCount - requiredAmount2;
            Debug.Log("New Total" + CDCount);
            buy.Play();
            timesUpgraded2 += 1;
            overallCount2 += 1;
            requiredAmount2 = Math.Round(basePrice2 * Math.Pow(1.5, timesUpgraded2));
            UpdatePriceText();
            UpdateTimesUpgradedText();
            UpdateCDCountText();
        }
    }

    /** WATER UPGRADE
        This contains:
        - 
    **/

    public void Upgrade3()
    {
        if (CDCount >= requiredAmount3)
        {
            CDCount = CDCount - requiredAmount3;
            Debug.Log("New Total" + CDCount);
            buy.Play();
            timesUpgraded3 += 1;
            overallCount3 += 1;

            upgradeMulti += 0.3;

            requiredAmount3 = Math.Round(basePrice3 * Math.Pow(2.5, timesUpgraded3));
            UpdatePriceText();
            UpdateTimesUpgradedText();
            UpdateCDCountText();
        }
    }

}
