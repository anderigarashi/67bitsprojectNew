using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class upgradeStore : MonoBehaviour
{
    [SerializeField] private PlayerValues playerVars;
    [SerializeField] private PricesData storePrices;

    
    public void BuyUpgradeStack()
    {
        if(playerVars.coinsPlayer >= storePrices.stackPrice)
        {
            playerVars.coinsPlayer -= storePrices.stackPrice;
            playerVars.maxStack += 1;
            UIManager.instance.UpdateCurrencyGameplay();
        }
    }
}
