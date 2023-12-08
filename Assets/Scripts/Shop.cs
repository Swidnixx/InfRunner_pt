using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerupManager;

    public Text coinsText;
    int coins;
    public Text batteryInfoText;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();

        DisplayBatteryInfo();
    }

    void DisplayBatteryInfo()
    {
        string info = "Lvl: " + powerupManager.Battery.level + "\n";
        if (powerupManager.Battery.upgraded != null)
        {
            info += "$" + powerupManager.Battery.upgradeCost + " to upgrade"; 
        }
        else
        {
            info += "Max level!";
        }
        batteryInfoText.text = info;
    }
}
