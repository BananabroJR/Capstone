using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BambooSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bamboo;

    private float timer = 5;

    private GameObject newBamboo;

   public static int score = 0;
    public static bool wentToSword = false;
    public static float counter = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        newBamboo = Instantiate(bamboo, transform.position, transform.rotation);
        wentToSword=true;
        counter++;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(newBamboo == null)
        {
          newBamboo = Instantiate(bamboo, transform.position, transform.rotation);
            score++;
        }

        if(timer <= 0)
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }
    }

  


}
