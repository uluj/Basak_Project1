using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathpoint : MonoBehaviour
{

    [SerializeField] GameObject defensePrefab;
    
    [SerializeField] bool isAvailable;

    public bool IsAvailable { get { return isAvailable; } }

    void OnMouseDown()
    {
        if (isAvailable)
        {
            Instantiate(defensePrefab, transform.position, Quaternion.identity);
            isAvailable = false;
        }

    }

    

}