using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooSlice : MonoBehaviour
{
   

    
  
 

    private Vector2 velocity = Vector2.zero;
    private Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
      
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
       

    }

    private void OnApplicationQuit()
    {
       Destroy(gameObject);
    }
}
