using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PunchPlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject[] bricks;

    public BrickAnimations particle1;
    public BrickAnimations particle2;
    public BrickAnimations particle3;
    public static bool punched = false;
    public static bool wenToPunch = false;
    public static int bricksDestroyed;
    private IEnumerator co;

    private void Start()
    {
        bricksDestroyed = 0;
        wenToPunch = true;
    }

    // Update is called once per frame
    void Update()
    {
       

       if(Input.GetKeyDown(KeyCode.Space) && !punched)
        {
            punched = true;
            float accuracy = 0;
            accuracy = BarTiming();

            if (bricks[0] && accuracy >= 0.85f)
            {
                co = particle1.PlayParteicle();
                 StartCoroutine(co);
              
                bricksDestroyed++;
            }
            if (!bricks[0] && bricks[1] && accuracy >= 0.85f)
            {
                co = particle2.PlayParteicle();
                StartCoroutine(co);
                
                bricksDestroyed++;
            }
            if (!bricks[1] && accuracy >= 0.85f)
            {
                co = particle3.PlayParteicle();
                StartCoroutine(co);
              
                bricksDestroyed++;
            }

            
        } 
    }

    private float BarTiming()
    {
        return bar.transform.localScale.y;
    }
}
