using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowSpawner : MonoBehaviour
{
    public static int arrowAmount;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject[] spawners;

    private GameObject newArrow;
    
   

    // Start is called before the first frame update
    void Start()
    {
        arrowAmount = Random.Range(6, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //arrowGotDestoryed is only true if there is no arrow on the screen so this will check if there is no arrow spawn a new one and set it to false
        //it gets set tot true in schmovement
        if(arrowAmount > 0 && ArrowSchmovment.arrowGotDestoyed) 
        {
            SpawnArrow(Random.Range(0, spawners.Length));
            
            ArrowSchmovment.arrowGotDestoyed = false;
        }
        
        if(arrowAmount <= 0) 
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }
    }

    private void SpawnArrow(int spawnNumber)
    {
        newArrow = Instantiate(arrow, spawners[spawnNumber].transform);
    }
}
