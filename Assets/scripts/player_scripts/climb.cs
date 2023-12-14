using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class climb : MonoBehaviour
{
    private bool closeLadder = false;
    public float climbSpeed = 6f;
    private Rigidbody2D RG2D;
    private float gravityScale;

    public bool climbing = false;
    private bool onGround = true;


    private move moveReference;

    public string layerName = "ladders";
    void Start()
    {
        RG2D = GetComponentInParent<Rigidbody2D>();
        gravityScale = RG2D.gravityScale; // getting the initial gravity scale

        moveReference = GetComponentInParent<move>(); // in order to check the ground variable
    }

    // Update is called once per frame
    void Update()
    {
        climber();
    }

    void climber()
    {
        if (closeLadder )
        {   

            float dir = Input.GetAxis("Vertical");
            climbing = false;
            if (dir != 0)
            {
                transform.parent.position += (Vector3.up * climbSpeed * dir * Time.deltaTime);
                climbing = true;

                // checking if we reach top or bottom 
                onGround = moveReference.OnGround;

            }

            if (onGround && !climbing)
            {
                resetMovement(); // enabling the initial movement
            }

            if (climbing)
            {
            // cancel gravity for the time being
            RG2D.gravityScale = 0f;

            // freezing the x movements
            RG2D.constraints = RigidbodyConstraints2D.FreezePositionX;

            }
                
            
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        int collidedLayer = LayerMask.NameToLayer(layerName);
        if (collidedLayer == collision.gameObject.layer)
        {
            closeLadder = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int collidedLayer = LayerMask.NameToLayer(layerName);
        if (collidedLayer == collision.gameObject.layer)
        {
            closeLadder = false;

            resetMovement();
        }
        
    }

    private void resetMovement()
    {
        // reseting the gravity changes for movement
        RG2D.constraints = RigidbodyConstraints2D.None;
        RG2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        RG2D.gravityScale = gravityScale; 

        climbing = false;
    }
}
