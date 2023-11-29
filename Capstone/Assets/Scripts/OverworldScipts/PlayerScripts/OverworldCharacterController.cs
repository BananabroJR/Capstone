using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class OverworldCharacterController : MonoBehaviour
{
    //Variables that are public (if any)
    public StatObject stats;


    //Variables that are supposed to be serialized
    [SerializeField] private float speed;

    [SerializeField] private RectTransform inventory;
 
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;


    //variables that will not show up in the untiy inspector
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
    private bool menuOpen = false;
    private bool inventoryOpen = false;
 
    bool faceRight = true;
  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
        inventory.transform.localScale = Vector3.zero;
        
      
    }

    // Update is called once per frame
    void Update()
    {
        //Dont move if talking
        if (DialougeManager.isActive)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        //Schmovement
        Vector2 direction = Vector2.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        velocity.x = direction.x * speed;
        velocity.y = direction.y * speed;
        if(!menuOpen)
        { 
            rb.velocity = velocity;
        }

        //animation jank
        animator.SetFloat("XSpeed", Mathf.Abs(velocity.x));
        animator.SetFloat("YSpeed", Mathf.Abs(velocity.y));


        if (rb.velocity.y < 0)
        {
            animator.SetBool("FaceUp", false);
            animator.SetBool("FaceRight", false);
          
            // faceRight = false;
        }
        else
        {
            animator.SetBool("FaceUp", true);
            animator.SetBool("FaceRight", false);
         
            // faceRight = false;
        }

        if (rb.velocity.x != 0)
        {
            animator.SetBool("FaceRight", true);
            animator.SetBool("FaceUp", false);
           
            // faceRight = true;
        }

        // flip character to face direction of movement (velocity)
        if (velocity.x > 0 && !faceRight) Flip();
        if (velocity.x < 0 && faceRight) Flip();

        //Open Menu
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            menuOpen = true;
            inventory.LeanScale(Vector3.one, 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!inventoryOpen)
            {
                menuOpen = false;
                inventory.LeanScale(Vector3.zero, 0f);
            }

          

        }




    }

 
 
    
    public void OpenInventory()
    {
        inventoryOpen = true;
        inventory.LeanScale(Vector3.one, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }

    }

    private void Flip()
    {
        faceRight = !faceRight;
        spriteRenderer.flipX = !faceRight;
    }


}

