using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMinigameResults : MonoBehaviour
{
    //This script is to take the results from all the different battle minigames and translate them to rng
    public BattleController battleController;
    public BattleEnemy enemy;
    public StatObject playerStats;
    public StatObject enemyStats;
  


    private float tempEnemyHealth;
    private bool hit = false;
    private bool crit = false;
    private bool ran = false;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(enemyStats.Health);
        if(BattleEnemy.enemyAmount <= 0)
        {
            SceneManager.LoadScene(sceneName: "TestOverWorldScene");
           
            
        }

        if(MazeControl.wentToRun)
        {
            if(MazeControl.result)
            {
                RunAway();
            }
            else
            {
                Debug.Log("How many times are you gonna run away? I captured 17 different times!");
            }

            MazeControl.wentToRun = false;
        }

        if(BambooSpawner.wentToSword)
        {
            hit = SwordMiniGameResults(BambooSpawner.score);
          

            Debug.Log(hit);
            if(hit)
            {
               enemyStats.Damage(playerStats.strength - enemyStats.defense); 
                hit = false;
            }
            BambooSpawner.wentToSword= false;
            BambooSpawner.score = 0;
        }
    }

    private bool SwordMiniGameResults(int score)
    {
      
        if(score == 2 || score == 3)
        {
            int hitChance = Random.Range(0, 3);
            if(hitChance == 0)
            {
                return true;
            }
          
        }
        if (score == 4 || score == 5)
        {
            int hitChance = Random.Range(0, 1);
            if (hitChance == 0)
            {
                return true;
            }
          
        }
        if (score == 6 || score == 7)
        {
            int hitChance = Random.Range(0, 3);
            if (hitChance < 0)
            {
                return true;
            }

        }
        if (score >= 8)
        {
            return true;

        }

        return false;
    }

    private void RunAway()
    {
        SceneManager.LoadScene(sceneName: "TestOverWorldScene");
    }

  
}
