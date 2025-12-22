using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "e552eb83d9a62c7d762c7851083cf79e19cd0efa9788934441845e075e6ea21d";

    void Start()
    {
        GetLeaderboard();
    }

    void OnEnable()
    {
        GameManager.OnSubmitScore += SetLeaderboardEntry;
    }

    void OnDisable()
    {
        GameManager.OnSubmitScore -= SetLeaderboardEntry;
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;

            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {
            GetLeaderboard();
        }));
    }
}
