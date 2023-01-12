using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public Enemy enemy;

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
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            enemy.rotEnemy.transform.Rotate(enemy.rotateEnemydir.y * Vector3.up, Space.World);
            GetNextPoints();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextPoints()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.lives -= enemy.damagePlayer;
    }
}
