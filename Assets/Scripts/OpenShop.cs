using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    #region GameObjects
    public GameObject shop;
    public GameObject sellShop;
    public GameObject ForgeShop;
    public GameObject UpgradeShop;
    #endregion

    void Start()
    {
        if (shop.activeSelf)
            shop.SetActive(false);
        if(sellShop.activeSelf)
            sellShop.SetActive(false);
        if (ForgeShop.activeSelf)
            ForgeShop.SetActive(false);
        if (UpgradeShop.activeSelf)
            UpgradeShop.SetActive(false);
    }

    public void OpenBuyshop()
    {
        shop.SetActive(true);
    }

    public void OpenSellshop()
    {
        sellShop.SetActive(true);
    }

    public void OpenForgeShop()
    {
        ForgeShop.SetActive(true);
    }

    public void OpenUpgradeShop()
    {
        UpgradeShop.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseAllShop();
        }
    }

    private void CloseAllShop()
    {
        shop.SetActive(false);
        sellShop.SetActive(false);
        ForgeShop.SetActive(false);
        UpgradeShop.SetActive(false);
    }
}
