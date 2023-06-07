using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpenButton : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    //[SerializeField] Button buttonOpenShopPanel; 

    public void OpenPanel()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OffPanel()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
