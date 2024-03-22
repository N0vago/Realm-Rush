using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;


    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;
    // Start is called before the first frame update
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        wayPoint = GetComponentInParent<WayPoint>();
        DesplayCoordinates();
        UdateObjectName();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DesplayCoordinates();
            UdateObjectName();
            
        }
        ColorCoordinates();
        ToggleLabel();
    }

    void ToggleLabel()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
            
        }
    }

    private void ColorCoordinates()
    {
        if(wayPoint.IsPlacable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color= blockedColor;
        }
    }

    void DesplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + " , " + coordinates.y;
    }

    void UdateObjectName()
    {
        transform.parent.name = coordinates.ToString(); 
    }
}
