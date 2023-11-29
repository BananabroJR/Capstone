using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
   
    public static float enemyAmount = 1;
    public StatObject playerStats;
    public StatObject enemyStats;
    [SerializeField] private Animator animator;

   
    public static bool defended = false;


    public StatObject stats;

    // Start is called before the first frame update
    void Start()
    {
            if (defended)
            {
                enemyStats.defense /= 2;
                defended = false;
            }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Action();


        if(stats.health <= 0)
        {
           Destroy(gameObject);
            enemyAmount--;
        }
    }

   private void Action()
    {


        if (BattleMinigameResults.wenToMinigame == true)
        {
          
            int attackRNG = Random.Range(1, 10);
            if(attackRNG <= 6 ) 
            {
                Attack();
                animator.SetTrigger("Attack");
            }
            else
            {
                Defend();
            }

            BattleMinigameResults.wenToMinigame = false; 
        }
    }

    private void Defend()
    {
        enemyStats.defense *= 2;
        defended = true;
    }

    private void Attack()
    {
        int hit = 0;
        hit = Random.Range(1, 10);

        if(hit <= 6) 
        {
            float damage = enemyStats.strength - playerStats.defense;
            playerStats.Damage(damage);
        }
    }

   
}
