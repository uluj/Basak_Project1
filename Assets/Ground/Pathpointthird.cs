using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathpointthird : MonoBehaviour
{
    [SerializeField] GameObject defensePrefabb;

    [SerializeField] bool isAvailable;


    void OnMouseDown()
    {
        if (isAvailable)
        {
            Instantiate(defensePrefabb, transform.position, Quaternion.identity);
            isAvailable = false;
        }

    }
}
