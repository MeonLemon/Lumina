using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public UnityEvent endEvent;
    public UnityEvent pauseEvent;
    public UnityEvent unpauseEvent;

    [SerializeField] private UnityEvent startEvent;
    public void GameStart()
    {
        startEvent.Invoke();
        gameState = GameState.Start;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Lumina2");
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        endEvent.Invoke();
    }

    public void SaveScore(float score)
    {
        PlayerPrefs.SetFloat("HighScore", score);
        PlayerPrefs.Save();
    }
}
