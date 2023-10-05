using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnBamboo : MonoBehaviour
{
   

    [SerializeField] private GameObject bamboo;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void CreateBamboo()
    {
        
        Instantiate(bamboo, transform.position, transform.rotation);

        

    }

    private void OnDestroy()
    {
        Destroy(bamboo);
    }

}
