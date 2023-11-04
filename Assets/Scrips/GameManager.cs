using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public Button restartButton;
    public List<Target> targets;
    public bool isGameActive;

    private float spawnRate = 1.5f;
    private int score;
    private int lives;
    private bool isPaused;


    // Start is called before the first frame update
   public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        titleScreen.SetActive(false);

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
    }

    private void CheckForPause()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckForPause();
        }
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score < 0 )
        {
            score = 0;
        }

        scoreText.text = " Score: " + score;
    }

    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;

        if (lives <= 0)
        {
            GameOver();
        }

        livesText.text = " Lives: " + lives;


    }

    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
