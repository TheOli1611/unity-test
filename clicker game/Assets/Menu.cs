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
    public Button claimButton;
    public Button claimButton2;
    public TextMeshProUGUI claimButtonText1;
    public TextMeshProUGUI claimButtonText2;
    public TextMeshProUGUI questAmountText;
    public TextMeshProUGUI questAmountText2;
    public int numClicks;
    public Boolean claimed = false;
    public Boolean claimed2 = false;
    public GameObject image;
    public GameObject claimNotif;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CDCountHighest < Main.CDCount)
        {
            CDCountHighest = Main.CDCount;
        }
        CDCountOverall = Main.CDOverall;
        CDCountOverallText.text = "Total CD: " + CDCountOverall.ToString() + "\nHighest CD: " + CDCountHighest.ToString() + "\nNumber of Shakers: " + main.timesUpgraded1 + "\nNumber of Cloud Helpers: " + main.timesUpgraded2;
        numClicks = main.questAmount;

        if (numClicks < 500)
        {
            questAmountText.text = numClicks.ToString() + "/500";
            claimButton.interactable = false;
        }
        if (numClicks == 500 && claimed == false)
        {
            questAmountText.text = numClicks.ToString() + "/500";
            claimButton.interactable = true;
            claimNotif.SetActive(true);
        }

        if (main.timesUpgraded1 < 10)
        {
            questAmountText2.text = main.timesUpgraded1.ToString() + "/10";
            claimButton2.interactable = false;
        }
        if (main.timesUpgraded1 == 10 && claimed2 == false)
        {
            questAmountText2.text = main.timesUpgraded1.ToString() + "/10";
            claimButton2.interactable = true;
            claimNotif.SetActive(true);
        }

        if (claimed == true && claimed2 == true)
        {
            image.SetActive(true);
        }
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

    public void ClaimButton()
    {
        Main.CDCount = Main.CDCount + 2000;
        main.UpdateCDCountText();
        claimButton.interactable = false;
        claimed = true;
        Debug.Log("added 2000");
        claimButtonText1.text = "+2000";
        claimNotif.SetActive(false);
    }

    public void ClaimButton2()
    {
        Main.CDCount = Main.CDCount + 2000;
        main.UpdateCDCountText();
        claimButton2.interactable = false;
        claimed2 = true;
        Debug.Log("added 2000");
        claimButtonText2.text = "+2000";
        claimNotif.SetActive(false);
    }
}
