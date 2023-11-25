using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeControl : MonoBehaviour
{
    Vector2 difference = Vector2.zero;

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    //this is temp for the buttons controls i will be using for right now
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;

    public static bool result; 
    public static bool wentToRun;
    private float speed = 5;
    bool faceRight = true;
    bool faceUp = false;
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
        float step = 2f;

        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x += step * Time.deltaTime;
        cameraPosition.y = gameObject.transform.position.y;
        Camera.main.gameObject.transform.position = cameraPosition;

        //animation jank
        animator.SetFloat("XSpeed", Mathf.Abs(velocity.x));
        animator.SetFloat("YSpeed", Mathf.Abs(velocity.y));


        if (rb.velocity.y < 0)
        {
            animator.SetBool("FaceUp", false);
            animator.SetBool("FaceRight", false);
            faceUp = false;
            // faceRight = false;
        }
        else
        {
            animator.SetBool("FaceUp", true);
            animator.SetBool("FaceRight", false);
            faceUp = true;
            // faceRight = false;
        }

        if (rb.velocity.x != 0)
        {
            animator.SetBool("FaceRight", true);
            animator.SetBool("FaceUp", false);
            faceUp = false;
            // faceRight = true;
        }

        // flip character to face direction of movement (velocity)
        if (velocity.x > 0 && !faceRight) Flip();
        if (velocity.x < 0 && faceRight) Flip();




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

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

    private void Flip()
    {
        faceRight = !faceRight;
        spriteRenderer.flipX = !faceRight;
    }


}
