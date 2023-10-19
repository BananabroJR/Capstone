using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeControl : MonoBehaviour
{
    Vector2 difference = Vector2.zero;

    public static bool result; 
    public static bool wentToRun;
    // Start is called before the first frame update
    void Start()
    {
        wentToRun= true;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("YEAH TAKE THAT YOU JUST GOT COLLIDED!");

        if (collision.gameObject.tag == "Floor")
        {
            result = false;
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }
    }

}
