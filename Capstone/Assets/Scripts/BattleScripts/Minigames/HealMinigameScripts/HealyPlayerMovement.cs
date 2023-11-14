using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealyPlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    [SerializeField] private float speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;


        direction.x = Input.GetAxisRaw("Horizontal");


        velocity.x = direction.x * speed;
        rb.velocity = velocity;
    }
}
