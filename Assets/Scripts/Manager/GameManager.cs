using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    //private string sceneGameOver = "GameOver";
    public GameObject gameOverUI;
    public GameObject imageHeart;
    public GameObject textLives;
    public GameObject CanvasShop;

    public WaveSpawner waveSpawner;
    public NodeUI nodeUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        nodeUI.DisableInfoUpgrade();
        imageHeart.SetActive(false);
        textLives.SetActive(false);
        CanvasShop.SetActive(false);
        Time.timeScale = 0f;
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1F;
        waveSpawner.waveIndex = 2;
        PlayerStats.RoundsPlayer = 0;
    }

    public void MenuGame()
    {
        Debug.Log("Menu Game");
    }
}
