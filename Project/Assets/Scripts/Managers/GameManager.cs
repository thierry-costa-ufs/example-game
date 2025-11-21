using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateGameState(GameState.MainMenu);
        SceneManager.LoadScene("02_MainMenu");
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (State)
        {
            case GameState.MainMenu:
                //TO-DO
                break;
            case GameState.Playing:
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                break;
            case GameState.GameOver:
                //TO-DO
                break;
            case GameState.Victory:
                //TO-DO
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("03_GameLevel");
        UpdateGameState(GameState.Playing);
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver,
    Victory
}