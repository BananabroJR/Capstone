using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealySchmovment : MonoBehaviour
{
    public static bool healyGotDestoyed = true;
    public StatObject player;


    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
 
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
            player.Heal(5);
            healyGotDestoyed = true;
            SpawnHealys.healyAmount--;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            healyGotDestoyed = true;
            SpawnHealys.healyAmount--;
        }
    }
}
