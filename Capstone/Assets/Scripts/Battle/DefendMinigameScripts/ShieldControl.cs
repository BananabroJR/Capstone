using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    private float speed = 5;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;

  
        direction.y = Input.GetAxisRaw("Vertical");

       
        velocity.y = direction.y * speed;
        rb.velocity = velocity;
    }
}
