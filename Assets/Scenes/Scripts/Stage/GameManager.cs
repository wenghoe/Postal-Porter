using UnityEngine;

public enum GameState { NullState, Intro, Game, Pause, Goal }
public delegate void OnStateChangeHandler();

internal class GameManager
{
    private static GameManager _instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    protected GameManager() { }

    // Singleton pattern implementation
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    }

    public GameState GetGameState()
    {
        return gameState;
    }

}