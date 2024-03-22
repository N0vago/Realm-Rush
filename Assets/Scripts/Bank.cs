using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startBalance = 150;
    [SerializeField] TextMeshProUGUI textMeshPro;
    int currentBalance;
    
    public int GetBalance {  get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startBalance;
        DisplayBalance();
    }

    public void Diposite(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        DisplayBalance();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        DisplayBalance();
        if (currentBalance < 0)
        {
            //Lose the game;
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void DisplayBalance ()
    {
        textMeshPro.text = "Gold: " + currentBalance.ToString();
    }

}
