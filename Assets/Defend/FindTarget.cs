using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 35f;
    //[SerializeField] string enemyTag = "Enemy1"; 
    Transform enemy;

   
    /*void Start()
    {
        enemy = FindObjectOfType<EnemyMovement>().transform;
        // Find enemy by the tag specified in the Inspector
        GameObject foundEnemy = GameObject.FindGameObjectWithTag(enemyTag);

        
        if (foundEnemy != null)
        {
            enemy = foundEnemy.transform;
        }
        else
        {
            Debug.LogWarning($"Enemy with tag '{enemyTag}' not found!");
        }
       
    }
    */

    
    void Update()
    {
        FindClosest();
        BarrelAiming();
    }

    void FindClosest()
    {
        Target[] enemies = FindObjectsOfType<Target>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;
        foreach (Target target in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, target.transform.position);
            if (enemyDistance < maxDistance) 
            {
                closestEnemy = target.transform;
                maxDistance = enemyDistance;
            }
        }
        enemy = closestEnemy;

        if (enemy != null)
        {
            Debug.Log("Found enemy: " + enemy.name);
        }
        else
        {
            Debug.Log("No enemies found.");
        }
    }

    void BarrelAiming()
    {
       

        float enemyDistance = Vector3.Distance(transform.position, enemy.position);

        barrel.LookAt(enemy);


        if (enemyDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        var emissionComponent = projectileParticles.emission;
        emissionComponent.enabled = isActive;
    }

}
