using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealySchmovment : MonoBehaviour
{
    public static bool healyGotDestoyed = true;


    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("You got healed!");
            healyGotDestoyed = true;
            SpawnHealys.healyAmount--;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("No Healies for you D:");
            healyGotDestoyed = true;
            SpawnHealys.healyAmount--;
        }
    }
}
