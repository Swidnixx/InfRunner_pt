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
    public Button upgradeBatteryButton;
    public Text magnetInfoText;
    public Button upgradeMagnetButton;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();

        DisplayBatteryInfo();
        DisplayMagnetInfo();
    }

    public void BuyBatteryUpgrade()
    {
        if( coins >= powerupManager.Battery.upgradeCost )
        {
            coins -= powerupManager.Battery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerupManager.Battery = powerupManager.Battery.upgraded;
            DisplayBatteryInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    public void BuyMagnetUpgrade()
    {
        if (coins >= powerupManager.Magnet.upgradeCost)
        {
            coins -= powerupManager.Magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerupManager.Magnet = powerupManager.Magnet.upgraded;
            DisplayMagnetInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
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
            upgradeBatteryButton.interactable = false;
        }
        batteryInfoText.text = info;
    }
    void DisplayMagnetInfo()
    {
        string info = "Lvl: " + powerupManager.Magnet.level + "\n";
        if (powerupManager.Magnet.upgraded != null)
        {
            info += "$" + powerupManager.Magnet.upgradeCost + " to upgrade";
        }
        else
        {
            info += "Max level!";
            upgradeMagnetButton.interactable = false;
        }
        magnetInfoText.text = info;
    }
}
