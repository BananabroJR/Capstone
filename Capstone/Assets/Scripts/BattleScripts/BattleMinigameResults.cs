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
    public static bool wenToMinigame = false;
    [SerializeField] private Animator animator;

    private float tempEnemyHealth;
    private bool hit = false;

    public static GameObject tempEnemy;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(enemyStats.Health);
        if(BattleEnemy.enemyWasDestroyed)
        {
            SceneManager.LoadScene(sceneName: "TestOverWorldScene");
          
            
        }

        if(MazeControl.wentToRun)
        {
            if(MazeControl.result)
            {
                RunAway();
            }
            MazeControl.wentToRun = false;
            wenToMinigame = true;
        }

        if(PunchPlayerScript.wenToPunch)
        {
            hit = PunchMinigameResults(PunchPlayerScript.bricksDestroyed);
            if (hit)
            {
                enemyStats.Damage(playerStats.strength - enemyStats.defense);
                animator.SetTrigger("Attack");
                hit = false;
            }
            PunchPlayerScript.wenToPunch = false;
            wenToMinigame = true;
        }

        if(AxePlayer.wentToAxe)
        {
            hit = AxeMinigameResults(AxePlayer.axePresses);
            if (hit)
            {
                enemyStats.Damage(playerStats.strength - enemyStats.defense);
                animator.SetTrigger("Attack");
                hit = false;
            }
            AxePlayer.axePresses = 0;
            AxePlayer.wentToAxe = false;
            wenToMinigame = true;
        }

        if(BambooSpawner.wentToSword)
        {
            hit = SwordMiniGameResults(BambooSpawner.score);
            if(hit)
            {
                enemyStats.Damage(playerStats.strength - enemyStats.defense);
                animator.SetTrigger("Attack");
                hit = false;
            }
            BambooSpawner.wentToSword= false;
            BambooSpawner.score = 0;
            wenToMinigame = true;
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

    private bool AxeMinigameResults(int axePresses)
    {
        if (axePresses >= 60)
        {
            return true;
        }
        if (axePresses >= 40)
        {
            int hitChance = Random.Range(0, 3);
            if (hitChance < 0)
            {
                return true;
            }
        }
        if(axePresses >= 30)
        {
            int hitChance = Random.Range(0, 1);
            if (hitChance == 0)
            {
                return true;
            }
        }
        if (axePresses >= 20)
        {
            int hitChance = Random.Range(0, 3);
            if (hitChance == 0)
            {
                return true;
            }
        }

        return false;
    }

    private bool PunchMinigameResults(int bricksDestroted)
    {
        if(bricksDestroted == 2)
        {
            int hitChance = Random.Range(0, 3);
            if (hitChance == 0)
            {
                return true;
            }
        }
        if(bricksDestroted == 3)
        {
            int hitChance = Random.Range(0, 1);
            if (hitChance == 0)
            {
                return true;
            }
        }
        if(bricksDestroted == 4)
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
