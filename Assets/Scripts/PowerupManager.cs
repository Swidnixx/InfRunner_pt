using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]
public class PowerupManager : ScriptableObject
{
    [SerializeField] private BatterySO _battery;
    [SerializeField] private MagnetSO _magnet;

    public BatterySO Battery
    {
        get
        {
            Init();
            return _battery;
        }
        set
        {
            _battery = value;
            PlayerPrefs.SetString("BatteryLevel", value.name);
            Debug.Log("Batter: " + value.name + " was saved");
        }
    }

    public MagnetSO Magnet
    {
        get
        {
            Init();
            return _magnet;
        }
        set
        {
            _magnet = value;
            PlayerPrefs.SetString("MagnetLevel", value.name);
            Debug.Log("Magnet: " + value.name + " was saved");
        }
    }

    bool initialised;
    void Init()
    {
        if(!initialised)
        {
            initialised = true;

            //Battery Load
            var tmpBattery = Resources.Load<BatterySO>(PlayerPrefs.GetString("BatteryLevel"));
            if(tmpBattery != null)
            {
                _battery = tmpBattery;
                Debug.Log("Battery: " + _battery.name + " was loaded");
            }
            else
            {
                Debug.Log("Default battery: " + _battery.name + " kept");
            }

            //Magnet Load
            var tmpMagnet = Resources.Load<MagnetSO>(PlayerPrefs.GetString("MagnetLevel"));
            if (tmpMagnet != null)
            {
                _magnet = tmpMagnet;
                Debug.Log("Magnet: " + _magnet.name + " was loaded");
            }
            else
            {
                Debug.Log("Default magnet: " + _magnet.name + " kept");
            }
        }
    }
}
