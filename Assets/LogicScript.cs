using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int SCORE_FOR_NEXT_LEVEL = 10;
    private int scoreToNextLevel;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject speedUpScreen;
    public AudioSource scoreAudio;
    public AudioSource gameOverAudio;
    public AudioSource speedUpAudio;
    private bool IsHeroAlive = true;
    private void Start()
    {
        scoreToNextLevel = SCORE_FOR_NEXT_LEVEL;
    }


    [ContextMenu("Increase Score")]
    public void AddScore(int i)
    {
        if (IsHeroAlive == false)
            return;
        playerScore += i;
        if(scoreToNextLevel == SCORE_FOR_NEXT_LEVEL - 2)
        {
            speedUpScreen.SetActive(false);
        }
        RefreshScoreText();
        scoreAudio.Play();
        scoreToNextLevel--;
        if (scoreToNextLevel == 0)
        {
            SpeedUp(5);
            scoreToNextLevel = SCORE_FOR_NEXT_LEVEL;
        }
    }

    private void Update()
    {
        if(IsHeroAlive == false && Input.GetKey(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void RefreshScoreText()
    {
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        //playerScore = 0;
        //RefreshScoreText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        IsHeroAlive = false;
        gameOverAudio.Play();
        gameOverScreen.SetActive(true);
    }

    private void SpeedUp(float speedUp)
    {
        speedUpAudio.Play();
        MovingScript.movingSpeed += speedUp;
        speedUpScreen.SetActive(true);
    }
}
