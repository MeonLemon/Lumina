using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;

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
}
