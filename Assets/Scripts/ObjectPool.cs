using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] int poolSize = 5;
    [SerializeField][Range(0.1f, 50f)] float spawnTime = 1f;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++) 
        {
            pool[i] = Instantiate(enemy, transform.position, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(Application.isPlaying)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void EnableObjectInPool()
    {
        foreach(GameObject obj in pool)
        {
            if(!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return;
            }
        }
    }
}
