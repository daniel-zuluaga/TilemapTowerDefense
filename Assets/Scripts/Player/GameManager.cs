using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    private string sceneGameOver = "GameOver";

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }

        void EndGame()
        {
            gameEnded = true;
            Debug.Log("GameOver");
            SceneManager.LoadScene(sceneGameOver);
        }
    }
}
