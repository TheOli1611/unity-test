using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Main : MonoBehaviour
{
    public Double CDCount;
    public Double requiredAmount = 20;
    public int timesUpgraded = 0;
    public Button upgradeAddButton;
    public GameObject upgradeShopUI;
    public Boolean upgradeShopOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        CDCount = 0;
        upgradeAddButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        requiredAmount = Math.Round(20 * Math.Pow(2.5, timesUpgraded));
        if (CDCount >= requiredAmount)
        {
            upgradeAddButton.interactable = true;
        }
        else
        {
            upgradeAddButton.interactable = false;
        }
        
    }

    public void AddCD()
    {
        CDCount = CDCount + 1 + timesUpgraded;
        Debug.Log(CDCount);
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
        if (CDCount >= requiredAmount)
        {
            CDCount = CDCount - requiredAmount;
            Debug.Log("New Total" + CDCount);
            timesUpgraded += 1;
        }
    }
}
