using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimation : MonoBehaviour
{
    public static float treeCuts;
  
    private Rigidbody2D rb;
    private Vector3 rotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        rotation.z = 90;
        Quaternion deltaRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        Debug.Log(treeCuts);
        if(treeCuts == 5)
        {
            treeCuts = 0;
            rb.AddForce(rb.velocity);
        }
    }
}
