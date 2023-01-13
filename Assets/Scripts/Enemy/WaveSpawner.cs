using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPosition;
    public GameObject[] enemyPrefab;

    public float timeBetweenWaves = 5;
    private float countDown = 2f;

    public TextMeshProUGUI waveCountdownTimer;
    public TextMeshProUGUI waveCountdown;

    public int waveIndex = 2;

    void Update()
    {
        int n = Random.Range(0, enemyPrefab.Length);
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        //countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = Mathf.Round(countDown).ToString();
        //string.Format("{0:00.00}", countDown);

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.RoundsPlayer++;
        waveCountdown.text = PlayerStats.RoundsPlayer.ToString();
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            float restartHealth = 2f;
            Enemy.instance.health *= PlayerStats.RoundsPlayer / restartHealth;
            yield return new WaitForSeconds(0.6f);

        }
    }

    void SpawnEnemy()
    {
        int n = Random.Range(0, enemyPrefab.Length);

        GameObject g = Instantiate(enemyPrefab[n], enemyPosition.transform.position, enemyPosition.transform.rotation);
    }
}
