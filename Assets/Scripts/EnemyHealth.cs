using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int healthPoints = 5;
    [SerializeField] int difficultyRam = 1;
    int currentHP = 0;

    Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        currentHP = healthPoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        currentHP--;
        if (currentHP == 0)
        {
            enemy.Reward();
            healthPoints += difficultyRam;
            gameObject.SetActive(false);
        }
    }
}
