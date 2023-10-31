using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSchmovment : MonoBehaviour
{
    public static bool arrowGotDestoyed = true;
   

    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
    private float speed = 5;
   

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        float step = -2f;
        direction.x = step;

        velocity.x = direction.x * speed;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Friendly")
        {
            Destroy(gameObject);
            Debug.Log("Aw you blocked me!");
            arrowGotDestoyed= true;
            ArrowSpawner.arrowAmount--;
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Take that you just got damaged!");
            arrowGotDestoyed= true;
            ArrowSpawner.arrowAmount--;
        }
    }
}
