using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] int poolsize = 5;

    [SerializeField] float waitTime = 1;

    GameObject[] pool;

    void Awake()
    {
        CreatePool();
    }

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    void CreatePool()
    {
        pool = new GameObject[poolsize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);

        }
    }
    

    void EnablePoolObjects()
    {

        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;

            }
        }
    }


    IEnumerator EnemySpawner()
    {
        while (true)
        {

            EnablePoolObjects();
            yield return new WaitForSeconds(waitTime);
        }
    }


}
