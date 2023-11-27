using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnHealys : MonoBehaviour
{
    public static int healyAmount;
    [SerializeField] private GameObject healy;
    [SerializeField] private GameObject[] spawners;

    private GameObject newHealy;

    // Start is called before the first frame update
    void Start()
    {
        healyAmount = Random.Range(6, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(healyAmount);
        if (healyAmount > 0 && HealySchmovment.healyGotDestoyed)
        {
            SpawnHealy(Random.Range(0, spawners.Length));

            HealySchmovment.healyGotDestoyed = false;
        }

        if (healyAmount <= 0)
        {
            SceneManager.LoadScene(sceneName: "TestBattleScene");
           BattleMinigameResults.wenToMinigame = true;
        }
    }

    private void SpawnHealy(int spawnNumber)
    {
        newHealy = Instantiate(healy, spawners[spawnNumber].transform);
    }
}
