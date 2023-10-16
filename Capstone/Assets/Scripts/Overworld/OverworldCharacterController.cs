using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class OverworldCharacterController : MonoBehaviour
{
    //Variables that are public (if any)
   
    //Variables that are supposed to be serialized
    [SerializeField] private float speed;
    [SerializeField] private RectTransform menu;

    //variables that will not show up in the untiy inspector
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
    private bool menuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        menu.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialougeManager.isActive)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        Vector2 direction = Vector2.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        velocity.x = direction.x * speed;
        velocity.y = direction.y * speed;
        if(!menuOpen)
        { 
            rb.velocity = velocity;
        }

        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            menuOpen = true;
            menu.LeanScale(Vector3.one, 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuOpen = false;
            menu.LeanScale(Vector3.zero, 0f);
        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }

    }


}

