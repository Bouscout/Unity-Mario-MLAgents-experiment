using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barel_move : MonoBehaviour
{


    public float moveSpeed = 12f; // movement speed
    public float direction = 0.0f;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if (direction != 0.0f)
        {
            // apply force in chosen direction
            Debug.Log("launch barel at direction : " + direction);
            rb2D.AddForce(Vector2.right * (direction * moveSpeed), ForceMode2D.Impulse);
            direction = 0.0f;
        }


    }
    
    


}
