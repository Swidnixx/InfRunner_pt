using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpVel = 7;
    public LayerMask groundMask; // co jest naszym groundem?
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;
    bool doubleJumped;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxCol.bounds.size, 0, Vector2.down, 0.55f, groundMask); // (0.94 + 0.1)
        grounded = hit.collider != null;
        if(Input.GetMouseButtonDown(0))
        {
            if(grounded)
            {
                doubleJumped = false;
                //jump
                Vector2 velocity = new Vector2(0, jumpVel);
                rb.velocity = velocity;
            }
            else if(!doubleJumped)
            {
                doubleJumped = true;
                //jump
                Vector2 velocity = new Vector2(0, jumpVel);
                rb.velocity = velocity;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (boxCol == null) return;

        //Boxcast test
        Color c = grounded ? Color.green : Color.red;
        Gizmos.color = c;
        Gizmos.DrawWireCube(transform.position + Vector3.down * 0.55f, boxCol.bounds.size);
    }
}
