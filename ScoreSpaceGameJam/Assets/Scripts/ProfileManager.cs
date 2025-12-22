using UnityEngine;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    public TMP_InputField usernameInput;

    void Start()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            usernameInput.text = PlayerPrefs.GetString("Username");
        }

        usernameInput.onEndEdit.AddListener(SaveUsername);
    }

    void SaveUsername(string username)
    {
        username = username.Trim();

        PlayerPrefs.SetString("Username", username);
        PlayerPrefs.Save();
    }
}
