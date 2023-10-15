using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private bool invOpen = false;

    [SerializeField] private GameObject invMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!invOpen)
            {
                Time.timeScale = 0; 
                invOpen = true;

            }
        }
    }
}
