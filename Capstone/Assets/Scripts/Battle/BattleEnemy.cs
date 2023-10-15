using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    [SerializeField] public float defaultHealth;
    public float enemyAmount = 1;

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.enemyHealth <= 0)
        {
            Destroy(gameObject);
            enemyAmount--;
        }
    }

    public void Damage(float damage)
    {
        GameManager.instance.enemyHealth -= damage;
    }   

}
