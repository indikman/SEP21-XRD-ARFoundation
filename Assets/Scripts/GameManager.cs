using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 10;
    public GameObject gameOverCanvas;
    public TMP_Text livesText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        RestartGame();
    }

    public void LoseLife()
    {
        lives--;

        //Update the life counter
        livesText.text = "LIVES : " + lives.ToString();

        // Game over if the lives are less than 0
        if (lives < 0)
        {
            // Game Over
            gameOverCanvas.SetActive(true);
        }
    }

    public void RestartGame()
    {
        lives = 10;
        livesText.text = "LIVES : " + lives.ToString();
        gameOverCanvas.SetActive(false);
    }
    
}
