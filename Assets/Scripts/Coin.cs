using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float waveSpeed = 1;
    public float waveDistance = 0.5f;
    Vector2 initialPos, targetPos;

    private void Start()
    {
        initialPos = transform.localPosition;
        targetPos = initialPos + Vector2.up * waveDistance;
    }

    private void Update()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * waveSpeed);
        if( Vector2.Distance(transform.localPosition, targetPos) < 0.1)
        {
            targetPos = initialPos;
            targetPos += Vector2.up * waveDistance * (transform.localPosition.y > initialPos.y ? -1 : 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.CoinCollected();
        }
    }
}
