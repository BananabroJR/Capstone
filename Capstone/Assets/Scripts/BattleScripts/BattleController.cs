using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public class BattleController : MonoBehaviour
{

    public static bool wenToMinigame = false;
    

    private bool inventoryOpen = false;

    [SerializeField] private RectTransform inventory;

    private void Start()
    {
        inventory.transform.localScale = Vector3.zero;
    }

    public void SwordAttack()
    {
        wenToMinigame = true;
        SceneManager.LoadScene(sceneName: "SwordCombatGameScene");

    }

    public void RunAway()
    {
        wenToMinigame = true;
        SceneManager.LoadScene(sceneName: "RunCombatGameScene");
    }

    public void Defend() 
    {
        
        SceneManager.LoadScene(sceneName: "DefendCombatGameScene");
    }

    public void Heal()
    {
        wenToMinigame = true;
        SceneManager.LoadScene(sceneName: "HealCombatMinigame");
    }

    private void Update()
    {
        if (inventoryOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryOpen = false;
            inventory.LeanScale(Vector3.zero, 0f);

        }
    }

    public void OpenInventory()
    {
        inventoryOpen = true;
        inventory.LeanScale(Vector3.one, 0);
    }

}
