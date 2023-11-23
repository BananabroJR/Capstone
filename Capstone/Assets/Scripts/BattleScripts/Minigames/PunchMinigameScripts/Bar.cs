using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Bar : MonoBehaviour
{
  

    [SerializeField] private GameObject bar;

    public static bool barIsFull = false;
    private bool isMoving = false;
    public static int barCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(barCount);
        if(barCount >= 3)
        {
            barCount = 0;
            SceneManager.LoadScene(sceneName: "TestBattleScene");
        }

        if(!barIsFull && !isMoving)
        {
            isMoving = true;
            MeterGoUp();
        }
        if(barIsFull && !isMoving)
        {
            isMoving = true;
            MeterGoDown();
            
        }

      

        if (bar.transform.localScale.y == 1 || bar.transform.localScale.y == 0)
        {
            isMoving = false;
            
        }
    }

    private void MeterGoUp()
    {
     
        LeanTween.scaleY(bar, 1, 0.5f);
        if (bar.transform.localScale.y == 1)
        {
            barIsFull = true;
        }
      
    }

    private void MeterGoDown()
    {
        LeanTween.scaleY(bar, 0, 0.5f);
        if (bar.transform.localScale.y == 0)
        {
            barIsFull = false;
            barCount++;
            PunchPlayerScript.punched = false;

        }
    }

}
