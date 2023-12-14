using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class barelClimb : MonoBehaviour
{
    private bool closeLadder = false;
    private Rigidbody2D RG2D;

    public bool climbing = false;
    private bool OnGround = false;
    private bool allowCollision = true;


    private BoxCollider2D groundCollider;
    private BoxCollider2D previousGround;


    // for handling the barel direction
    private float barelLastDirection = 1.0f;
    private barel_move barelDirection;

    public string layerName = "ladders";
    void Start()
    {
        RG2D = GetComponentInParent<Rigidbody2D>();

        barelDirection = GetComponentInParent<barel_move>();

        //resetMovement();
        OnGround = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        climber();
    }

    void climber()
    {
        if (closeLadder && OnGround)
        {
            int randomNumber = Random.Range(0, 5);

            // creating a probability 4 / 6 to go down
            if (randomNumber >= 1)
            {
                // freeze x position and disable the collision
                stopMovement();
                DisableCollisionGround();
                climbing = true;
            }
        }
        else if(!allowCollision && !climbing)
        {   
          
            resetMovement();
            EnableCollisionGround();
            allowCollision = true;
           
        }

        else
        {
            climbing = false;
        }
      
    }

    // to handle whenever the barel is on the ground or not
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // ground
        if (!OnGround)
        {
            int groundColliderMask = LayerMask.NameToLayer("ground");
            if (groundColliderMask == collision.gameObject.layer)
            {
                OnGround = true;
                previousGround = groundCollider;
                groundCollider = collision.gameObject.GetComponent<BoxCollider2D>();
                Debug.Log("On the ground now and collision is set to : " + allowCollision);
            }
        }

       

        // ladder
        if (!closeLadder)
        {
            int ladderCollider = LayerMask.NameToLayer(layerName);
            if (ladderCollider == collision.gameObject.layer)
            {
                Debug.Log("hit ladder");
                closeLadder = true;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ground
        if (OnGround) { 
            int groundColliderMask = LayerMask.NameToLayer("ground");
            if (collision is BoxCollider2D && groundColliderMask == collision.gameObject.layer)
            {
                //OnGround = false;
                Debug.Log("exiting ground now");
                Debug.Log("no collision with : " + collision.gameObject.name);
                OnGround = false;
            }
        }


        // ladder
        if (closeLadder)
        {

            int ladderCollider = LayerMask.NameToLayer(layerName);
            if (ladderCollider == collision.gameObject.layer)
            {
                Debug.Log("Exiting ladder");
                closeLadder = false;
            }

        }


    }


    private void resetMovement()
    {
        Debug.Log("enabling everything back");

        // reseting the gravity changes for movement
        RG2D.constraints = RigidbodyConstraints2D.None;
        climbing = false;

        barelDirection.direction = barelLastDirection * -1;
        barelLastDirection = barelLastDirection * -1;


    }
    private void DisableCollisionGround()
    {
        if (allowCollision)
        {

            CircleCollider2D parentCollider = transform.parent.GetComponent<CircleCollider2D>();
            CircleCollider2D playerCollider = GetComponent<CircleCollider2D>();

            Physics2D.IgnoreCollision(parentCollider, groundCollider ,true);
            Physics2D.IgnoreCollision(playerCollider, groundCollider, true);

            Debug.Log("collision disabled with : " + groundCollider);

            allowCollision = false;
            OnGround = false;
        }
    }

    private void EnableCollisionGround()
    {
        if (!allowCollision)
        {

            CircleCollider2D parentCollider = transform.parent.GetComponent<CircleCollider2D>();
            CircleCollider2D playerCollider = GetComponent<CircleCollider2D>();

            Physics2D.IgnoreCollision(parentCollider, previousGround, false);
            Physics2D.IgnoreCollision(playerCollider, previousGround, false);
                                                                             
            Debug.Log("collision enabled with : " + previousGround);
            allowCollision = true;
        }
    }

    private void stopMovement()
    {
        // freezing the x movements
        RG2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
