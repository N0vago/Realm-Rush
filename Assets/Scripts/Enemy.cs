using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void Reward()
    {
        if (bank == null) {  return; }
        bank.Diposite(goldReward);
    }
    
    public void StealGold()
    {
        if(bank == null) {  return; }
        bank.Withdraw(goldPenalty);
    }
}
