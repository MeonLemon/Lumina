using UnityEngine;
using TMPro;

public class ScoreTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScore;

    private float timerValue;

    private void Start()
    {
        // Initialize timer values
        timerValue = 0f;
        highScore.text = FormatTime(PlayerPrefs.GetFloat("HighScore"));
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Start)
        {
            // Update timer value based on elapsed time
            timerValue += Time.deltaTime;

            // Update TextMeshPro text
            timerText.text = FormatTime(timerValue);
        }

        if(GameManager.Instance.gameState == GameState.End)
        {
            if (PlayerPrefs.GetFloat("HighScore") < timerValue)
            {
                GameManager.Instance.SaveScore(timerValue);
            } 
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000f);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}