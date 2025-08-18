using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public GameObject gameOver;

    public TextMeshProUGUI bestRecordText;

    public TextMeshProUGUI count;

    public TextMeshProUGUI score;

    private float surviveTime;
    private int coinCount = 0;

    private bool isGameOver = false;

    private void Start()
    {
        gameOver.SetActive(false);
    }
    private void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = $"Time: {Mathf.FloorToInt(surviveTime)}";
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


        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime);
            //PlayerPrefs.Save();
        }
        int totalScore = (coinCount * 10) + Mathf.FloorToInt(surviveTime);

        bestRecordText.text = $"Best Record: {Mathf.FloorToInt(totalScore)}";
        //bestRecordText.text = $"Best Record: {Mathf.FloorToInt(bestTime)}";
    }

    public void AddCoin()
    {
        coinCount++;
        count.text = $"Coin Count: {coinCount}";
    }
    public void AddScore()
    {
        int totalScore = (coinCount * 10) + Mathf.FloorToInt(surviveTime);
        score.text = $"Score: {totalScore}";
       
    }
}
