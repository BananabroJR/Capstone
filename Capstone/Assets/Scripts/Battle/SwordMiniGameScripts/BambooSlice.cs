using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooSlice : MonoBehaviour
{
    public SpawnBamboo spawnBamboo;

    // Start is called before the first frame update
    void Start()
    {
       // spawnBamboo = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnBamboo>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
          
           Destroy(gameObject);
           
        }
    }

    private void OnDestroy()
    {
        spawnBamboo.CreateBamboo();

    }
}
