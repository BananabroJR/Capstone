using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PunchPlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject[] bricks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            float accuracy = 0;
            accuracy = BarTiming();

            if (bricks[0] && accuracy >= 0.85f)
            {
                Destroy(bricks[0]);
            }
            if (!bricks[0] && accuracy >= 0.85f)
            {
                Destroy(bricks[1]);
            }
            if (!bricks[1] && accuracy >= 0.85f)
            {
                Destroy(bricks[2]);
            }    
            
        } 
    }

    private float BarTiming()
    {
        return bar.transform.localScale.y;
    }
}
