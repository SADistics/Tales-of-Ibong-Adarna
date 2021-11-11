using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAlchemistShop : MonoBehaviour
{
    #region GameObjects
    public GameObject shop;
    public GameObject sellShop;
    #endregion

    void Start()
    {
        if (shop.activeSelf)
            shop.SetActive(false);
        if (sellShop.activeSelf)
            sellShop.SetActive(false);
    }

    public void OpenBuyshop()
    {
        shop.SetActive(true);
    }

    public void OpenSellshop()
    {
        sellShop.SetActive(true);
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
    }
}
