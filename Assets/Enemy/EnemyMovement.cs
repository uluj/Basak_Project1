using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Pathpoint> path = new List<Pathpoint>();
    [SerializeField][Range(0f, 4f)] float speed = 1f;
    [SerializeField] string pathTag = "Path"; // Add this line

    void OnEnable()
    {
        PathFinding();
        StartAgain();
        StartCoroutine(PathFollowing());
    }

    void PathFinding()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag(pathTag); // Use the variable here
        foreach (Transform child in parent.transform)
        {
            Pathpoint pathpoint = child.GetComponent<Pathpoint>();
            if (pathpoint != null)
            {
                path.Add(pathpoint);
            }
        }
    }

    void StartAgain()
    {
        transform.position = path[0].transform.position;
        Vector3 initialLookDirection = path[1].transform.position;
        transform.LookAt(initialLookDirection);
    }

    IEnumerator PathFollowing()
    {
        foreach (Pathpoint waypoint in path)
        {
            Vector3 start = transform.position;
            Vector3 end = waypoint.transform.position;
            float travelAmount = 0f;

            transform.LookAt(end);

            while (travelAmount < 1f)
            {
                travelAmount += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(start, end, travelAmount);
                yield return new WaitForEndOfFrame();
            }
        }

        gameObject.SetActive(false);
    }
}
