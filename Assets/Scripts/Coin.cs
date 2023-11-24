using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float waveSpeed = 1;
    public float waveDistance = 0.5f;
    Vector2 initialPos, targetPos;
    Transform player;

    private void Start()
    {
        initialPos = transform.localPosition;
        targetPos = initialPos + Vector2.up * waveDistance;

        player = GameObject.FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        bool inRange = Vector2.Distance(transform.position, player.position) < GameManager.Instance.magnet.magnetDistance;
        if (GameManager.Instance.magnet.magnetActive && inRange)
        {
            Atract();
        }
        else
        {
            Floating();
        }
    }

    public float atractionSpeed = 5.5f;
    void Atract()
    {            
        Vector2 nextPos = Vector2.MoveTowards(
                transform.position,
                player.position,
                Time.deltaTime * atractionSpeed);
        transform.position = nextPos;
    }

    void Floating()
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
