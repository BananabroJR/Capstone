using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class OverworldCharacterController : MonoBehaviour
{
    //Variables that are public (if any)
   
    //Variables that are supposed to be serialized
    [SerializeField] private float speed;

    //variables that will not show up in the untiy inspector
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialougeManager.isActive) return;

        Vector2 direction = Vector2.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        velocity.x = direction.x * speed;
        velocity.y = direction.y * speed;

        rb.velocity = velocity;

      
       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }

    }


}

