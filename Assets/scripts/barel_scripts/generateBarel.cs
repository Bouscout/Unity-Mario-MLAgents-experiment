using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBarel : MonoBehaviour
{
    public GameObject barel;

    private float delay = 10f;
    private float counter = 11;

    private float offset_X = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        createBarel();   
    }

    void createBarel()
    {
        if (counter >= delay)
        {
            Vector3 newPos = transform.position + (Vector3.right * offset_X);
            Instantiate(barel, newPos, transform.rotation);

            counter = 0;
            Debug.Log("new barel");
        }

        counter += Time.deltaTime;
    }
}
