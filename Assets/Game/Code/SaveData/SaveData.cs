using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    [SerializeField] private PlayerValues playerVars;


    void Awake()
    {
        instance = this;
        LoadGame();
    }


    private void LoadGame()
    {
        playerVars.coinsPlayer = PlayerPrefs.GetInt("coins");
        playerVars.currentStack = PlayerPrefs.GetInt("currentStack");
        playerVars.maxStack = PlayerPrefs.GetInt("maxStack");
        playerVars.currentSkin = PlayerPrefs.GetInt("currentSkin");
        playerVars.punchForce = PlayerPrefs.GetInt("punchForce");
        if(playerVars.punchForce < 600) { playerVars.punchForce = 650; }

        int result0 = PlayerPrefs.GetInt("haveSkin0");
        int result1 = PlayerPrefs.GetInt("haveSkin1");
        int result2 = PlayerPrefs.GetInt("haveSkin2");
        int result3 = PlayerPrefs.GetInt("haveSkin3");
        if(result0 == 1) { playerVars.haveSkin0 = true; } else { playerVars.haveSkin0 = false; }
        if(result1 == 1) { playerVars.haveSkin1 = true; } else { playerVars.haveSkin1 = false; }
        if(result2 == 1) { playerVars.haveSkin2 = true; } else { playerVars.haveSkin2 = false; }
        if(result3 == 1) { playerVars.haveSkin3 = true; } else { playerVars.haveSkin3 = false; }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("coins", playerVars.coinsPlayer);
        PlayerPrefs.SetInt("currentStack", playerVars.currentStack);
        PlayerPrefs.SetInt("maxStack", playerVars.maxStack);
        PlayerPrefs.SetInt("currentSkin", playerVars.currentSkin);
        PlayerPrefs.SetInt("punchForce", playerVars.punchForce);

        if(playerVars.haveSkin0) { PlayerPrefs.SetInt("haveSkin0", 1); } else { PlayerPrefs.SetInt("haveSkin0", 0); }
        if(playerVars.haveSkin1) { PlayerPrefs.SetInt("haveSkin1", 1); } else { PlayerPrefs.SetInt("haveSkin1", 0); }
        if(playerVars.haveSkin2) { PlayerPrefs.SetInt("haveSkin2", 1); } else { PlayerPrefs.SetInt("haveSkin2", 0); }
        if(playerVars.haveSkin3) { PlayerPrefs.SetInt("haveSkin3", 1); } else { PlayerPrefs.SetInt("haveSkin3", 0); }
    }
}
