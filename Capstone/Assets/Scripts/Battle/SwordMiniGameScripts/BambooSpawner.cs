using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bamboo;

 

    private GameObject newBamboo;

   [SerializeField] private float score = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        newBamboo = Instantiate(bamboo, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(newBamboo == null)
        {
          newBamboo = Instantiate(bamboo, transform.position, transform.rotation);
            score++;
        }
    }

    private void OnApplicationQuit()
    {
       
    }


}
