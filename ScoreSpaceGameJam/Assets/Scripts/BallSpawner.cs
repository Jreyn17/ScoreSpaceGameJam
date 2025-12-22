using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ball;

    [Header("Time")]
    [SerializeField] private float startSpawnInterval = 5f; //Starting interval is 5

    [SerializeField] private float spawnInterval; //Time between spawns
    private float timer = 0f; //Timer
    private bool timerRunning = false; //If game is running, timer is running

    void OnEnable()
    {
        GameManager.OnGameStarted += ResetSpawner;
        GameManager.OnGameStarted += StartTimer;
        GameManager.OnGameOver += StopTimer;
        GameManager.OnLevelUp += LevelUp;
    }

    void OnDisable()
    {
        GameManager.OnGameStarted -= ResetSpawner;
        GameManager.OnGameStarted -= StartTimer;
        GameManager.OnGameOver -= StopTimer;
        GameManager.OnLevelUp -= LevelUp;
    }

    void Update()
    {
        if (!timerRunning)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0f;
        }
    }

    private void ResetSpawner()
    {
        spawnInterval = startSpawnInterval;
        timer = 0f;
    }

    private void StartTimer()
    {
        timerRunning = true;
    }
    
    private void StopTimer()
    {
        timerRunning = false;
    }

    private void LevelUp(int level)
    {
        spawnInterval = Mathf.Max(1f, spawnInterval - 0.4f);
    }

    private void SpawnBall()
    {
        Instantiate(ball, new Vector2(Random.Range(-4f, 4f), Random.Range(-10f, -6f)), Quaternion.Euler(0f, 0f, Random.Range(0f, 180f)));
    }
}
