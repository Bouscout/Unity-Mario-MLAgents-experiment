using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // for jump and climbing options
    public float jumpHeight = 6f;
    public bool OnGround = true;
    private string groundColliderTag;
    public BoxCollider2D groundDetector;
   
    
    public float moveSpeed = 1.0f; // movement speed
    private float moveDir = 0.0f;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<BoxCollider2D>();
        groundColliderTag = groundDetector.gameObject.tag ;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
        
    }

    void movement()
    {
        moveDir = Input.GetAxis("Horizontal");
        if (moveDir != 0.0f )
        {
            // apply force in chosen direction
            rb2D.AddForce(Vector2.right * (moveDir * moveSpeed));
            moveDir = 0.0f; // reset for new direction 
        }


    }

    void jump()
    {
    
            // check if the player is on the ground with the box collider
            float jump = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            rb2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

    
    }

    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!OnGround)
        {
            int collidedLayer = LayerMask.NameToLayer("ground");
            if (collision is BoxCollider2D && collidedLayer == collision.gameObject.layer)
            {
                OnGround = true;
            }
        }

        int barelLayer = LayerMask.NameToLayer("barel");
        if (barelLayer == collision.gameObject.layer)
        {
            Debug.Log("player hit !!!");
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            int collidedLayer = LayerMask.NameToLayer("ground");
            if (collision is BoxCollider2D && collidedLayer == collision.gameObject.layer)
            {
                OnGround = false;
            }
        
    }
}
