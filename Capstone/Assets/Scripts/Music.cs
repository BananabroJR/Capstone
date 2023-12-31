using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public static Music instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "TestOverWorldScene")
        {
            Music.instance.GetComponent<AudioSource>().Pause();
        }
        else
        {

            Music.instance.GetComponent<AudioSource>().Play();
        }
    }
}
