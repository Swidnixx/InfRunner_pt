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
            return _battery;
        }
        set
        {
            _battery = value;
        }
    }

    public MagnetSO Magnet
    {
        get
        {
            return _magnet;
        }
        set
        {
            _magnet = value;
        }
    }
}
