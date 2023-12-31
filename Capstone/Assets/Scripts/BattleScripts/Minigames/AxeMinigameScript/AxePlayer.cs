using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AxePlayer : MonoBehaviour
{
    private float timer = 8;
    public static int axePresses;
    public static bool wentToAxe;
    [SerializeField] private Animator animator;
    private void Start()
    {
        wentToAxe = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            axePresses++;
            TreeAnimation.treeCuts++;
           
        }


        if (timer <= 0)
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }
    }
}
