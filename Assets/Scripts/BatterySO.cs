using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BatterySO : ScriptableObject
{
    public bool active;
    public float duration = 5;
    public float speedBoost = 2.5f;

    public int level = 1;
    public int upgradeCost = 100;
    public BatterySO upgraded;
}
