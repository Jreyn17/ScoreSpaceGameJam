using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject statsPanel;

    void Start()
    {
        statsPanel.SetActive(false);
    }

    void OnEnable()
    {
        GameManager.OnLivesChanged += HandleLivesChanged;
        GameManager.OnPointsChanged += HandlePointsChanged;
        GameManager.OnGameStarted += HandleGameStarted;
        GameManager.OnGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.OnLivesChanged -= HandleLivesChanged;
        GameManager.OnPointsChanged -= HandlePointsChanged;
        GameManager.OnGameStarted -= HandleGameStarted;
        GameManager.OnGameOver -= HandleGameOver;
    }

    
    private void HandleLivesChanged(int lives)
    {
        if (livesText != null) livesText.text = $"Lives: {lives}";
    }

    private void HandlePointsChanged(int points)
    {
        if (pointsText != null) pointsText.text = $"Points: {points}";
    }

    private void HandleGameStarted()
    {
        if (startPanel != null) startPanel.SetActive(false);
        if (statsPanel != null) statsPanel.SetActive(true);
    }

    private void HandleGameOver()
    {
        if (startPanel != null) startPanel.SetActive(true);
        if (statsPanel != null) statsPanel.SetActive(false);
    }

    
}
