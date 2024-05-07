using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manageButtons : MonoBehaviour
{
    public InputField playerNameInputField;
    private string playerName = "";
    public void IntroToGame()
    {
        SceneManager.LoadScene("Game");
        StorePlayerName();
        Debug.Log(RetrievePlayerName());
    }

    public void GameToExit()
    {

        SceneManager.LoadScene("Exit");

    }

    public void ExitToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }

    public void StorePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", playerNameInputField.text);

    }
    public string RetrievePlayerName()
    {
        playerName = PlayerPrefs.GetString("PlayerName");
        return playerName;
    }
    public int RetrievePlayerScore()
    {
        return PlayerPrefs.GetInt("PlayerScore");
    }
}
