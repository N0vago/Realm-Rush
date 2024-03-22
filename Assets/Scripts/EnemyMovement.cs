using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> wayPoints = new List<WayPoint>();
    [SerializeField][Range(0.1f, 5f)] float speed = 1f;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PrintWaypointName());
        
    }

    void FindPath()
    {
        wayPoints.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform) 
        {
            wayPoints.Add(child.GetComponent<WayPoint>());
        }
    }

    void ReturnToStart()
    {
        gameObject.transform.position = wayPoints[0].transform.position;
    }

    IEnumerator PrintWaypointName()
    {
        foreach (var waypoint in wayPoints)
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = waypoint.transform.position;

            float travelPercent = 0f;

            transform.LookAt(newPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(currentPosition, newPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
        }

        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
