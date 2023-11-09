using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
   
    public static float enemyAmount = 1;

    private float health;
    private float mana;
    private float strength;
    private float magic;
    private float defense;
    
    public StatObject stats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(stats.health <= 0)
        {
           Destroy(gameObject);
            enemyAmount--;
        }
    }

  


}
