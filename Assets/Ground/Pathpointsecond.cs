using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathpointsecond : MonoBehaviour
{
    [SerializeField] GameObject defensePrefabs;

    [SerializeField] bool isAvailable;


    void OnMouseDown()
    {
        if (isAvailable)
        {
            Instantiate(defensePrefabs, transform.position, Quaternion.identity);
            isAvailable = false;
        }

    }
}
