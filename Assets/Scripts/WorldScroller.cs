using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public WorldSegment ground1, ground2;

    public WorldSegment[] prefabSegments;

    private void Update()
    {
        float speed = GameManager.Instance.worldSpeed;
        Vector2 deltaPos = new Vector2(-speed, 0) * Time.deltaTime;
        ground1.transform.position += (Vector3)deltaPos;
        ground2.transform.Translate(deltaPos);

        if(ground2.transform.position.x < 0)
        {
            Destroy(ground1.gameObject);
            WorldSegment newSegment = Instantiate(prefabSegments[Random.Range(0,prefabSegments.Length)]);

            float d = ground2.sizeX * 0.5f + newSegment.sizeX * 0.5f;

            newSegment.transform.position = ground2.transform.position + new Vector3(d, 0, 0);

            ground1 = ground2;
            ground2 = newSegment;
        }
    }
}
