using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;

    Bank bank;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null)
        {
            return false;
        }

        if(bank.GetBalance >= towerCost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(towerCost);
            return true;
        }

        return false;
    }
}
