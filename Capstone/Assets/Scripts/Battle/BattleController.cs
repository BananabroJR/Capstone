using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    

    public float damage;

    public void SwordAttack()
    {
       
        SceneManager.LoadScene(sceneName: "SwordCombatGameScene");
    }

}
