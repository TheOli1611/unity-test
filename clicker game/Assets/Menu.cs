using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("General")]
    public static Double CDCountOverall;
    public static Double CDCountHighest = 0;
    public TextMeshProUGUI CDCountOverallText;
    public GameObject StatsUI;
    public GameObject SettingsUI;
    public Main main;
    [Header("Quests")]
    public TextMeshProUGUI claimButtonText1;
    public TextMeshProUGUI questAmountText;
    public int numClicks;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(CDCountHighest < Main.CDCount)
        {
            CDCountHighest = Main.CDCount;
        }
        CDCountOverall = Main.CDOverall;
        CDCountOverallText.text = "Total CD: " + CDCountOverall.ToString() + "\nHighest CD: " + CDCountHighest.ToString() + "\nNumber of Shakers: " + main.timesUpgraded1 + "\nNumber of Cloud Helpers: " + main.timesUpgraded2;
        numClicks = main.questAmount;
    }

    public void StatsOpen()
    {
        StatsUI.SetActive(true);
        SettingsUI.SetActive(false);
    }

    public void SettingsOpen()
    {
        StatsUI.SetActive(false);
        SettingsUI.SetActive(true);
    }
}
