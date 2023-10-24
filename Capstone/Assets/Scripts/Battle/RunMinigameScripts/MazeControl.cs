using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeControl : MonoBehaviour
{
    Vector2 difference = Vector2.zero;

    //this is temp for the buttons controls i will be using for right now
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    public static bool result; 
    public static bool wentToRun;
    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        wentToRun= true;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Uncomment line after next week I want to use mouse controls for this but for right now just to test camera and win condition i will be using WASD buttons
        //transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;


        //Current schmovement set up this is temp button set
        Vector2 direction = Vector2.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        velocity.x = direction.x * speed;
        velocity.y = direction.y * speed;
        rb.velocity = velocity;

        //Camera Scrolling
        float step = 0.005f;

        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x += step;
        cameraPosition.y = gameObject.transform.position.y;
        Camera.main.gameObject.transform.position = cameraPosition;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("YEAH TAKE THAT YOU JUST GOT COLLIDED!");

        if (collision.gameObject.tag == "Floor")
        {
            result = false;
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }

        if (collision.gameObject.tag == "Friendly")
        {
            result = true;
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }
    }

}
