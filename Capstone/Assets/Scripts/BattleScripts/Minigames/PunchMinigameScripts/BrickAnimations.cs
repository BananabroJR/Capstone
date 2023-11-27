using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickAnimations : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayParteicle()
    {
        particle.Play();
        sprite.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(gameObject);
    }

}
