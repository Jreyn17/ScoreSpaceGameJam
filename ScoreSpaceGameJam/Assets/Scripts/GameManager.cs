using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int startingLives = 3;

    public static event Action OnGameStarted;
    public static event Action<int> OnLivesChanged;
    public static event Action<int> OnPointsChanged;
    public static event Action OnGameOver;

    public int points { get; private set; }
    public int lives { get; private set; }
    public bool IsRunning { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        ResetGameState();
    }

    private void ResetGameState()
    {
        points = 0;
        lives = Mathf.Max(0, startingLives);
        IsRunning = false;

        OnPointsChanged?.Invoke(points);
        OnLivesChanged?.Invoke(lives);
    }

    #region Buttons
    public void OnPlayClicked()
    {
        ResetGameState();
        IsRunning = true;

        OnGameStarted?.Invoke();
    }

    public void OnLeaderboardClicked()
    {

    }
    #endregion

    public void AddPoints(int amount)
    {
        if (!IsRunning) return;
        if (lives <= 0) return;

        points += amount;
        OnPointsChanged?.Invoke(points);
    }

    public void LoseLife(int amount)
    {
        if (!IsRunning) return;
        if (lives <= 0) return;

        lives = Mathf.Max(0, lives - amount);
        OnLivesChanged?.Invoke(lives);

        if (lives == 0)
        {
            IsRunning = false;
            OnGameOver?.Invoke();
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            
            foreach(GameObject ball in balls) 
            {
                Destroy(ball);
            }
        }
    }
}
