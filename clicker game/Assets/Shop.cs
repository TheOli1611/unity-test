using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shopMenu;
    public Button openShopButton;
    public Boolean shopOpened;
    public Button closeShopButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShopUIOpen()
    {
        shopMenu.SetActive(true);
        shopOpened = true;
    }
    public void ShopUIClose()
    {
        shopMenu.SetActive(false);
        shopOpened = false;
    }
}
