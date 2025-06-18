using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shop : MonoBehaviour
{
    [Header("General")]
    public GameObject shopMenu;
    public Button openShopButton;
    public bool shopOpened;
    public Button closeShopButton;
    public Main main;
    public int multiply = 1;
    public GameObject buyPopup;
    public AudioSource music;

    [Header("Gift")]
    public Button dailyGiftButton;
    public TextMeshProUGUI dailyGiftButtonText;
    public bool dailyGiftClaimed = false;

    [Header("Random")]
    public Button randomButton;
    public GameObject popUpUI;
    public Button closePopUp;
    public GameObject somethingUI;
    public GameObject shakerImage;
    public GameObject cloudHelperImage;
    public GameObject nothingUI;

    [Header("Shop Buttons")]
    public Button buy1;
    public TextMeshProUGUI priceText;
    public Button buy2;
    public TextMeshProUGUI priceText2;
    public Button buy3;
    public TextMeshProUGUI priceText3;

    [Header("Cursor")]
    public Texture2D cursorTexture;
    private Vector2 cursorHotspot = Vector2.zero;
    [Header("CD Shop")]
    public Button CDBuy1;
    public TextMeshProUGUI CDCprice1;
    public Button CDBuy2;
    public TextMeshProUGUI CDCprice2;
    public Button CDBuy3;
    public TextMeshProUGUI CDCprice3;
    public GameObject CDpopupUI;
    public Button CDclosePopUp;
    public GameObject CDshop;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Main.CDCount < 3000)
        {
            randomButton.interactable = false;
        }
        else
        {
            randomButton.interactable = true;
        }
    }

    public void ShopUIOpen()
    {
        shopMenu.SetActive(true);
        shopOpened = true;
        music.time = 0.7f;
        music.Play();
        main.mainMusic.Pause();
    }
    public void ShopUIClose()
    {
        shopMenu.SetActive(false);
        shopOpened = false;
        music.Pause();
        main.mainMusic.Play();
    }

    public void DailyGift()
    {
        Main.CDCount += 200;
        Main.CDOverall += 200;
        main.buy.Play();
        dailyGiftButton.interactable = false;
        dailyGiftButtonText.text = "CLAIMED";
        main.UpdateCDCountText();
    }

    public void RandomButton()
    {
        int num = Random.Range(1, 4);
        Debug.Log(num);
        main.buy.Play();
        popUpUI.SetActive(true);
        Main.CDCount -= 3000;
        main.UpdateCDCountText();

        if (num == 1)
        {
            somethingUI.SetActive(true);
            shakerImage.SetActive(true);

            main.overallCount += 10;
            main.UpdateTimesUpgradedText();
            Debug.Log("Building count:" + main.overallCount);
        }
        else if (num == 2)
        {
            somethingUI.SetActive(true);
            cloudHelperImage.SetActive(true);

            main.overallCount2 += 10;
            main.UpdateTimesUpgradedText();
            Debug.Log("Building count:" + main.overallCount2);
        }
        else if (num == 3)
        {
            nothingUI.SetActive(true);
            Main.CDCount += 1000;
            Main.CDOverall += 1000;
            main.UpdateCDCountText();
        }
    }

    public void ClosePopUp()
    {
        popUpUI.SetActive(false);
        HideEverything();
    }

    public void HideEverything()
    {
        somethingUI.SetActive(false);
        shakerImage.SetActive(false);
        cloudHelperImage.SetActive(false);
        nothingUI.SetActive(false);
        buyPopup.SetActive(false);
    }

    public void MultiplyBuy()
    {
        multiply = 2;
        main.buy.Play();
        popUpUI.SetActive(true);
        buyPopup.SetActive(true);
        buy2.interactable = false;
        priceText2.text = "SOLD";
    }

    public void PackageBuy()
    {
        Main.CDCount += 2000;
        Main.CDOverall += 2000;
        main.buy.Play();
        main.overallCount += 3;
        main.overallCount2 += 3;
        main.UpdateCDCountText();
        main.UpdateTimesUpgradedText();
        popUpUI.SetActive(true);
        buyPopup.SetActive(true);
        buy3.interactable = false;
        priceText3.text = "SOLD";
    }

    public void CursorBuy()
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.ForceSoftware);
        main.buy.Play();
        popUpUI.SetActive(true);
        buyPopup.SetActive(true);
        buy1.interactable = false;
        priceText.text = "SOLD";
    }

    public void CDBuyPackage()
    {
        Main.CDCount += 2000;
        Main.CDOverall += 2000;
        main.buy.Play();
        main.UpdateCDCountText();
        CDpopupUI.SetActive(true);
        CDCprice1.text = "+2000 | SOLD";
        CDBuy1.interactable = false;
    }
    public void CDBuyPackage2()
    {
        Main.CDCount += 6000;
        Main.CDOverall += 6000;
        main.buy.Play();
        main.UpdateCDCountText();
        CDpopupUI.SetActive(true);
        CDCprice2.text = "+6000 | SOLD";
        CDBuy2.interactable = false;
    }
    public void CDBuyPackage3()
    {
        Main.CDCount += 10000;
        Main.CDOverall += 10000;
        main.buy.Play();
        main.UpdateCDCountText();
        CDpopupUI.SetActive(true);
        CDCprice3.text = "+10000 | SOLD";
        CDBuy3.interactable = false;
    }
    public void CDClosePopUp()
    {
        CDpopupUI.SetActive(false);
    }
    public void Back()
    {
        CDshop.SetActive(false);
    }
    public void OpenCDShop()
    {
        CDshop.SetActive(true);
    }
}
