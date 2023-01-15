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
    public float startSpeed;
    public float speed;
    public Transform rotEnemy;
    public int damagePlayer;
    public float health;
    public int moneyEnemy;

    [Header("Components")]
    public Vector3 rotateEnemydir;

    public GameObject effectsEnemyPrefab;

    private void Start()
    {
        startSpeed = speed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        PlayerStats.Money += moneyEnemy;
        GameObject enemyEffects = Instantiate(effectsEnemyPrefab, transform.position, Quaternion.identity);
        Destroy(enemyEffects, 0.6f);
        Destroy(gameObject);
    }

}
