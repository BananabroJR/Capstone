using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwordMiniGame : MonoBehaviour
{
     [SerializeField] private GameObject bamboo;

   

    private Vector3 startPosition = Vector3.zero;
    private bool overBamboo = false;
    private float overBambooTimer;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0)) 
        {
            Vector3 offset = Input.mousePosition - startPosition;
            Debug.Log(offset.sqrMagnitude);
        }

      
    }

    void OnMouseOver()
    {
        Debug.Log(gameObject.name);
        

    }

    private void OnMouseEnter()
    {
        overBamboo = true;
    }

    private void OnMouseExit()
    {
        overBamboo = false;
    }
}
