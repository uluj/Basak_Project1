using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteAlways]

public class CoordinateSystem : MonoBehaviour
{

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color updatedColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Pathpoint pathpoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        pathpoint = GetComponentInParent<Pathpoint>();
        DisplayCoordinates();
    }


    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectsName();
        }

        ColorUpdates();
        LabelToggling();
       
    }


    void LabelToggling()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void ColorUpdates()
    {

        if (pathpoint.IsAvailable) 
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = updatedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;


    }

    void UpdateObjectsName()
    {
        transform.parent.name = coordinates.ToString();
    }


}
