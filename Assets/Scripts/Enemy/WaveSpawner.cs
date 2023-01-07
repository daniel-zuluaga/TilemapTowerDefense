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
    private int waveCount;

    void Update()
    {
        int n = Random.Range(0, enemyPrefab.Length);
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countDown);
            //Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        waveCount++;
        waveCountdown.text = waveCount.ToString();
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            float restartHealth = 2.25f;
            Enemy.instance.health *= waveCount / restartHealth;
            yield return new WaitForSeconds(0.2f);

        }
    }

    void SpawnEnemy()
    {
        int n = Random.Range(0, enemyPrefab.Length);

        GameObject g = Instantiate(enemyPrefab[n], enemyPosition.transform.position, enemyPosition.transform.rotation);
    }
}
