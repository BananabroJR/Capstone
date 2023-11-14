using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AxePlayer : MonoBehaviour
{
    private float timer = 8;
    private int axePresses;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            axePresses++;
            Debug.Log(axePresses);
        }


        if (timer <= 0)
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }
    }
}
