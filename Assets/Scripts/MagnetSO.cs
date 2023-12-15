using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MagnetSO : ScriptableObject
{
    public bool magnetActive;
    public float magnetDistance = 2.5f;
    public float magnetDuration = 5;

    public int level = 1;
    public int upgradeCost = 100;
    public MagnetSO upgraded;
}
