using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    //public Canvas mycanvas;

    [SerializeField]  int maxHit = 4;
    [SerializeField]  int currentHit = 0;

    void Start()
    {
        currentHit = maxHit;
    }

    void OnParticleCollision(GameObject other)
    {
        HitProcedure();
   

    }

    void HitProcedure()
    {
        currentHit--;



        if (currentHit <= 0)
        {
            gameObject.SetActive(false);
            //mycanvas.gameObject.SetActive(true);
        }
    }

}