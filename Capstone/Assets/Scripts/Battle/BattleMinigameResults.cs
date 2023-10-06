using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMinigameResults : MonoBehaviour
{
    //This script is to take the results from all the different battle minigames and translate them to rng
    public BattleController battleController;
    public BattleEnemy enemy;

    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(enemy.enemyAmount <= 0)
        {
            SceneManager.LoadScene(sceneName: "TestOverWorldScene");
        }

        if(BambooSpawner.wentToSword)
        {
           hit = SwordMiniGameResults(BambooSpawner.score);

            if(hit)
            {
                enemy.Damage(battleController.damage);
                hit = false;
            }
        }
    }

    private bool SwordMiniGameResults(int score)
    {
        if(score == 0 || score == 1)
        {
            return false;
        }
        if(score == 2 || score == 3)
        {
            int hitChance = Random.Range(0, 3);
            if(hitChance == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (score == 4 || score == 5)
        {
            int hitChance = Random.Range(0, 1);
            if (hitChance == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (score == 6 || score == 7)
        {
            int hitChance = Random.Range(0, 3);
            if (hitChance == 0)
            {
                return false;
            }
            else
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
}
