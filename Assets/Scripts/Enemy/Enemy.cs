using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("Stats Enemy")]
    public float speed = 4f;
    public Transform rotEnemy;
    public int damagePlayer;
    public float health;
    public int moneyEnemy;

    [Header("Components")]
    private Transform target;
    private int wavepointIndex = 0;
    public Vector3 rotateEnemydir;

    public GameObject effectsEnemyPrefab;

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

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += moneyEnemy;
        GameObject enemyEffects = Instantiate(effectsEnemyPrefab, transform.position, Quaternion.identity);
        Destroy(enemyEffects, 0.6f);
        Destroy(gameObject);
    }

    void GetNextPoints()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
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
        PlayerStats.lives -= damagePlayer;
    }

}
