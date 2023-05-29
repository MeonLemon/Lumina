using UnityEngine;
using TMPro;

public class ScoreTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timerValue;

    private void Start()
    {
        // Initialize timer values
        timerValue = 0f;
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
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000f);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}