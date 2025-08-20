using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;

    public TextMeshProUGUI bestRecordText;

    public TextMeshProUGUI timeText;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI currentCoinText;

    private float surviveTime;

    private int score = 0;

    private bool isGameOver = false;


    private void Start()
    {
        score = 0;
        surviveTime = 0f;
        isGameOver = false;
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if(!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = $"Time: {Mathf.FloorToInt(surviveTime)}";

            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();

            score = (player.GetCoinCount() * 10) + Mathf.FloorToInt(surviveTime);
            scoreText.text = $"Score: {score}";
            currentCoinText.text = $"Coins Count: {player.GetCoinCount()}";
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }



    }

    public void EndGame()
    {
        isGameOver = true;

        gameOver.SetActive(true);

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }

        bestRecordText.text = $"Best Record: {Mathf.FloorToInt(bestScore)}";
    }
}