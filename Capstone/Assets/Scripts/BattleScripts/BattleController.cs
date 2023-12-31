using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public enum WeaponEquipped
{
    NONE,
    SWORD,
    AXE
}

public class BattleController : MonoBehaviour
{

 

    public static WeaponEquipped equippment = WeaponEquipped.NONE;
    

    private bool inventoryOpen = false;

    [SerializeField] private RectTransform inventory;

    private void Start()
    {
        inventory.transform.localScale = Vector3.zero;
    }

    public void Attack()
    {
        if(equippment == WeaponEquipped.SWORD)
        {
            SwordAttack();
        }
        if (equippment == WeaponEquipped.NONE)
        {
            PunchAttack();
        }
        if(equippment == WeaponEquipped.AXE) 
        {
            AxeAttack();
        }
    }

    private void AxeAttack()
    {
     
        SceneManager.LoadScene(sceneName: "AxeCombatMinigame");
    }

    private void PunchAttack()
    {
      
        SceneManager.LoadScene(sceneName: "PunchCombatGameScene");
    }

    private void SwordAttack()
    {
        SceneManager.LoadScene(sceneName: "SwordCombatGameScene");

    }

    public void RunAway()
    {
        SceneManager.LoadScene(sceneName: "RunCombatGameScene");
    }

    public void Defend() 
    {
        
        SceneManager.LoadScene(sceneName: "DefendCombatGameScene");
    }

    public void Heal()
    {
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
