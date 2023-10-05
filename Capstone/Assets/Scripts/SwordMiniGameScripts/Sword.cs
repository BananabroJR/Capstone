using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public BambooSlice bambooSlice;
    private bool isCutting = false;
    [SerializeField] private float minCuttingSpeed = 0.001f;
    [SerializeField] private GameObject bamboo;

    private Vector2 prevPosition = Vector2.zero;

    private Camera cam;
    private Rigidbody2D rb;
    private CircleCollider2D circle;
    private float timer = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateBlade();
        }

        Debug.Log(bambooSlice.bambooDestroyed);

        if(bambooSlice.bambooDestroyed)
        {
            timer -= Time.time;
            Debug.Log(timer);
            if(timer <= 0) 
            {
                RespawnBamboo();
            }
        }

    }

    void StartCutting()
    {
        isCutting = true;
        circle.enabled = false;
        prevPosition = cam.ScreenToWorldPoint(Input.mousePosition); 
    }

    void StopCutting()
    {
        isCutting = false;
        circle.enabled = false;
    }

    void UpdateBlade()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - prevPosition).magnitude * Time.deltaTime;
        if(velocity > minCuttingSpeed)
        {
            circle.enabled = true;

        }
        else
        {
            circle.enabled = false;

        }

        prevPosition = newPosition;
    }

    void RespawnBamboo()
    {
        Instantiate(bamboo);
    }

}
