using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSegment : MonoBehaviour
{
    public SpriteRenderer groundSprite;
    public float sizeX => groundSprite.bounds.size.x;
}
