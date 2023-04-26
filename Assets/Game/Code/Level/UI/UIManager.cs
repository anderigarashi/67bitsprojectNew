using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("UI Refs")]
    [SerializeField] private Image UI_buyShop;
    [SerializeField] private Image UI_upgradeStacks;
    [SerializeField] private TextMeshProUGUI txtValueCoins;
    [SerializeField] private TextMeshProUGUI txtValueStacks;


    [Header("Data Refs")]
    [SerializeField] private PlayerValues playerVars;
    [SerializeField] private PricesData storePrices;


    [Header("Refs Stores Text")]
    [SerializeField] private TextMeshProUGUI txtValueSkin00;
    [SerializeField] private TextMeshProUGUI txtValueSkin01;
    [SerializeField] private TextMeshProUGUI txtValueSkin02;
    [SerializeField] private TextMeshProUGUI txtValueSkin03;
    [SerializeField] private TextMeshProUGUI txtLevelAtualStack;
    [SerializeField] private TextMeshProUGUI txtNextLevelStack;
    

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUIMenus();
    }


    [ContextMenu("Start Update UI Texts")]
    public void UpdateUIMenus()
    {
        txtValueSkin00.text = "Selected";
        txtValueSkin00.color = Color.red;
        if(playerVars.haveSkin1) txtValueSkin01.text = "Obtained"; else { txtValueSkin01.text = storePrices.skin1price.ToString() + " Coins"; }
        if(playerVars.haveSkin2) txtValueSkin02.text = "Obtained"; else { txtValueSkin02.text = storePrices.skin2price.ToString() + " Coins"; }
        if(playerVars.haveSkin3) txtValueSkin03.text = "Obtained"; else { txtValueSkin03.text = storePrices.skin3price.ToString() + " Coins"; }
        txtLevelAtualStack.text = "Stack Level Atual: " + playerVars.maxStack.ToString();
        txtNextLevelStack.text = "Next Level: " + (playerVars.maxStack + 1).ToString();
    }


    [ContextMenu("Update Currency Gameplay")]
    public void UpdateCurrencyGameplay()
    {
        txtValueCoins.text = playerVars.coinsPlayer.ToString();
        txtValueStacks.text = playerVars.currentStack.ToString() + "/" + playerVars.maxStack.ToString();
        txtLevelAtualStack.text = "Stack Level Atual: " + playerVars.maxStack.ToString();
        txtNextLevelStack.text = "Next Level: " + (playerVars.maxStack + 1).ToString();
    }
  

    //---- Update Text When Buyed or Selected a skin ----//
    public void SelectedSkin00()
    {
        txtValueSkin00.text = "Selected";
        txtValueSkin00.color = Color.red;
        if(playerVars.haveSkin1){txtValueSkin01.text = "Obtained"; txtValueSkin01.color = Color.yellow;}
        if(playerVars.haveSkin2){txtValueSkin02.text = "Obtained"; txtValueSkin02.color = Color.yellow;}
        if(playerVars.haveSkin3){txtValueSkin03.text = "Obtained"; txtValueSkin03.color = Color.yellow;}
    }
    public void SelectedSkin01()
    {
        txtValueSkin01.text = "Selected";
        txtValueSkin01.color = Color.red;
        if(playerVars.haveSkin0){txtValueSkin00.text = "Obtained"; txtValueSkin00.color = Color.yellow;}
        if(playerVars.haveSkin2){txtValueSkin02.text = "Obtained"; txtValueSkin02.color = Color.yellow;}
        if(playerVars.haveSkin3){txtValueSkin03.text = "Obtained"; txtValueSkin03.color = Color.yellow;}
    }
    public void SelectedSkin02()
    {
        txtValueSkin02.text = "Selected";
        txtValueSkin02.color = Color.red;
        if(playerVars.haveSkin1){txtValueSkin01.text = "Obtained"; txtValueSkin01.color = Color.yellow;}
        if(playerVars.haveSkin0){txtValueSkin00.text = "Obtained"; txtValueSkin00.color = Color.yellow;}
        if(playerVars.haveSkin3){txtValueSkin03.text = "Obtained"; txtValueSkin03.color = Color.yellow;}
    }
    public void SelectedSkin03()
    {
        txtValueSkin03.text = "Selected";
        txtValueSkin03.color = Color.red;
        if(playerVars.haveSkin1){txtValueSkin01.text = "Obtained"; txtValueSkin01.color = Color.yellow;}
        if(playerVars.haveSkin2){txtValueSkin02.text = "Obtained"; txtValueSkin02.color = Color.yellow;}
        if(playerVars.haveSkin0){txtValueSkin00.text = "Obtained"; txtValueSkin00.color = Color.yellow;}
    }


    [ContextMenu("Open & Close Shops")]
    public void Open_Close_BuyShop(bool result) { UI_buyShop.gameObject.SetActive(result); }
    public void Open_Close_UpgradeStacks(bool result) { UI_upgradeStacks.gameObject.SetActive(result); }
}
