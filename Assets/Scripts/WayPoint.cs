using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower tower;



    public bool IsPlacable { get {  return isPlaceable; } }
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = tower.CreateTower(tower, transform.position);
            
            isPlaceable = !isPlaced;
        }

    }
}
