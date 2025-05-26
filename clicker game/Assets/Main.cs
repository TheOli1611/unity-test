using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Main : MonoBehaviour
{
    [Header("General")]
    public Double CDCount;
    public TextMeshProUGUI CDCountText;
    public GameObject upgradeShopUI;
    public Boolean upgradeShopOpened = false;
    [Header("Shaker Upgrade")]
    public Double requiredAmount1 = 20;
    public int timesUpgraded1 = 0;
    public Button upgradeButton1;
    public TextMeshProUGUI priceText1;
    public TextMeshProUGUI timesUpgradedText1;
    

    // Start is called before the first frame update
    void Start()
    {
        CDCount = 0;
        upgradeButton1.interactable = false;
        UpdatePriceText();
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

    }

    public void AddCD()
    {
        CDCount = CDCount + 1 + timesUpgraded1;
        Debug.Log(CDCount);
        UpdateCDCountText();
    }

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

    public void Upgrade1()
    {
        if (CDCount >= requiredAmount1)
        {
            CDCount = CDCount - requiredAmount1;
            Debug.Log("New Total" + CDCount);
            timesUpgraded1 += 1;
            requiredAmount1 = Math.Round(20 * Math.Pow(2.5, timesUpgraded1));
            UpdatePriceText();
            UpdateTimesUpgradedText();
            UpdateCDCountText();
        }
    }

    public void UpdatePriceText()
    {
        priceText1.text = requiredAmount1.ToString() + " CD";
    }

    public void UpdateTimesUpgradedText()
    {
        timesUpgradedText1.text = timesUpgraded1.ToString();
    }

    public void UpdateCDCountText()
    {
        CDCountText.text = CDCount.ToString();
    }
}
