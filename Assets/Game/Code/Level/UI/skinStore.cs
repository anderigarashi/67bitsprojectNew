using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skinStore : MonoBehaviour
{
    [SerializeField] private PlayerValues playerVars;
    [SerializeField] private PricesData storePrices;


    public void BuySkin00()
    {
        if(playerVars.coinsPlayer >= storePrices.skin0price && playerVars.haveSkin0 == false)
        {
            playerVars.coinsPlayer -= storePrices.skin0price;
            playerVars.currentSkin = 0;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            playerVars.haveSkin0 = true;
            UIManager.instance.SelectedSkin00();
        }else if(playerVars.haveSkin0)
        {
            playerVars.currentSkin = 0;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            UIManager.instance.SelectedSkin00();
        }
        
    }
    public void BuySkin01()
    {
        if(playerVars.coinsPlayer >= storePrices.skin1price && playerVars.haveSkin1 == false)
        {
            playerVars.coinsPlayer -= storePrices.skin1price;
            playerVars.currentSkin = 1;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            playerVars.haveSkin1 = true;
            UIManager.instance.SelectedSkin01();
        }else if(playerVars.haveSkin1)
        {
            playerVars.currentSkin = 1;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            UIManager.instance.SelectedSkin01();
        }
        
    }
    public void BuySkin02()
    {
        if(playerVars.coinsPlayer >= storePrices.skin2price && playerVars.haveSkin2 == false)
        {
            playerVars.coinsPlayer -= storePrices.skin2price;
            playerVars.currentSkin = 2;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            playerVars.haveSkin2 = true;
            UIManager.instance.SelectedSkin02();
        }else if(playerVars.haveSkin2)
        {
            playerVars.currentSkin = 2;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            UIManager.instance.SelectedSkin02();
        }
        
    }
    public void BuySkin03()
    {
        if(playerVars.coinsPlayer >= storePrices.skin3price && playerVars.haveSkin3 == false)
        {
            playerVars.coinsPlayer -= storePrices.skin3price;
            playerVars.currentSkin = 3;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            playerVars.haveSkin3 = true;
            UIManager.instance.SelectedSkin03();
        }else if(playerVars.haveSkin3)
        {
            playerVars.currentSkin = 3;
            Player.instance.UpdateSkinAtual(playerVars.currentSkin);
            UIManager.instance.SelectedSkin03();
        }
    }
}
