using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject startGamePanel, gameOverPanel;
    [SerializeField] TextMeshProUGUI scoreTxt, gameOverScoreTxt, gameOverHighScoreTxt, startGameHighscoreTxt;
    PlayerScript playerScr;

    int score = 0;
    int loadedHighscore;
    bool hasGameStarted = false;
    bool hasGameOver = false;

    private void Awake()
    {
        InvokeRepeating("SpawnObstacle", 0f, 1.5f);
        playerScr = FindObjectOfType<PlayerScript>();

        loadedHighscore = PlayerPrefs.GetInt("highscore");
        startGameHighscoreTxt.SetText(loadedHighscore.ToString());
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!hasGameStarted)
            {
                hasGameStarted = true;
                playerScr.StartGame();
                startGamePanel.SetActive(false);
            }
            else if (hasGameOver)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void SpawnObstacle()
    {
        if (hasGameStarted && !hasGameOver)
        {
            Vector2 playerPos = playerScr.GetPosition();
            GameObject tmpObstacle = Instantiate(obstaclePrefab, new Vector2(playerPos.x + 8, Random.Range(-3f, 3f)), Quaternion.identity);
        }
    }

    public void ScorePoint()
    {
        score++;
        scoreTxt.SetText(score.ToString());
    }

    public void GameOver()
    {
        hasGameOver = true;
        gameOverPanel.SetActive(true);
        gameOverScoreTxt.SetText(score.ToString());
     
        if(score > loadedHighscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            gameOverHighScoreTxt.SetText(score.ToString());
        }
        else
        {
            gameOverHighScoreTxt.SetText(loadedHighscore.ToString());
        }
    }

}
