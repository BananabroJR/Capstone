using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public StatObject playerStats;
    public StatObject enemyStats;
    public InventoryObject inventory;

  
   
    

    private void Awake()
    {


        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

   
}
