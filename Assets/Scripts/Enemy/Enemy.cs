using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    public Transform rotEnemy;

    private Transform target;
    private int wavepointIndex = 0;
    public Vector3 rotateEnemydir;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            rotEnemy.transform.Rotate(rotateEnemydir.y * Vector3.up, Space.World);
            GetNextPoints();
        }
    }

    void GetNextPoints()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
