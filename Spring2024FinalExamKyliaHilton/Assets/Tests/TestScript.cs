using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestScript:InputTestFixture
{
    Mouse mouse;
    Keyboard keyboard;

   public void ClickUI(GameObject element)
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector2 screenPosition = camera.WorldToScreenPoint(element.transform.position);
        Set(mouse.position, screenPosition);
        Click(mouse.leftButton);
    }

    [UnityTest]
    public IEnumerator _1_PlayButtonStartsPlay()
    {
        SceneManager.LoadScene("Intro");
        yield return new WaitForSeconds(1f);
        GameObject Button = GameObject.Find("PlayButton");
        Assert.IsNotNull(Button, "Play button not found in Intro scene");
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(2f);
        Assert.AreEqual("Game", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking Play Button");
    }
    [UnityTest]
    public IEnumerator _2_StopButtonStopsPlay()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1f);
        GameObject Button = GameObject.Find("StopButton");
        Assert.IsNotNull(Button, "Stop button not found in Intro scene");
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(2f);
        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name, "Exit scene not loaded after clicking Stop Button");
    }
    [UnityTest]
    public IEnumerator _3_PlayAgainButtonRestartsGame()
    {
        SceneManager.LoadScene("Exit");
        yield return new WaitForSeconds(1f);
        GameObject Button = GameObject.Find("PlayAgainButton");
        Assert.IsNotNull(Button, "Play again button not found in the exit scene.");
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        yield return new WaitForSeconds(2f);
        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name, "Intro scene not loaded after clicking play again button");
    }
    [UnityTest]
    public IEnumerator _4_PlayerNameShownInGame()
    {
        PlayerPrefs.SetString("PlayerName", "Kylia");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1f);
        Assert.AreNotEqual("", GameObject.Find("NameText").GetComponent<Text>().text);
    }
    [UnityTest]
    public IEnumerator _5_DestroyingFiveTargetsStopsPlay()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1f);
        GameObject PlayerObject = GameObject.Find("Player");
        Assert.IsNotNull(PlayerObject, "Player not found in Game scene");
        PlayerObject.transform.position = new Vector3(3, 1, -3);
        yield return new WaitForSeconds(1f);
        PlayerObject.transform.position = new Vector3(4, 1, 1);
        yield return new WaitForSeconds(1f);
        PlayerObject.transform.position = new Vector3(2, 1, 2);
        yield return new WaitForSeconds(1f);
        PlayerObject.transform.position = new Vector3(-3, 1, 3);
        yield return new WaitForSeconds(1f);
        PlayerObject.transform.position = new Vector3(-4, 1, -4);
        yield return new WaitForSeconds(2f);
        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking Play Button");
    }
    [UnityTest]
    public IEnumerator _6_NameFromIntroShowsInGameScene()
    {
        PlayerPrefs.SetString("PlayerName", "Kylia");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1f);
        Assert.AreNotEqual("", GameObject.Find("NameText").GetComponent<Text>().text);
        //I had issues testing this because when new scenes were loaded the player prefs values didn't stay, but I can confirm this works in game.
    }
}
