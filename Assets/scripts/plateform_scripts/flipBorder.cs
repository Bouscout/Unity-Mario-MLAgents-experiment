using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipBorder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerObject;
    private climb climbRef;

    private bool climbing = false;

    private PlatformEffector2D platformManager;
    void Start()
    {
        climbRef = playerObject.GetComponent<climb>();

        platformManager = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        climbing = climbRef.climbing;
        climbing = false;
        if (climbing)
        {
            platformManager.surfaceArc = 0f;
        }
        else
        {
            platformManager.surfaceArc = 180f;
        }
    }
}
