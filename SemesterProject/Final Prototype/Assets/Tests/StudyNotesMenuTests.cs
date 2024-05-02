using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement; // for loading and  restarting game
using UnityEngine.InputSystem;
using TMPro;// so we can use mouse and keyboard

public class StudyNotesMenuTests : InputTestFixture
{
    Mouse mouse;
    Keyboard keyboard;

        public override void Setup()
        {
            SceneManager.LoadScene("studyNotesMenu");
            base.Setup();
            mouse = InputSystem.AddDevice<Mouse>();
            keyboard = InputSystem.AddDevice<Keyboard>();
        }

        public override void TearDown() // overrides inputtestfixture.teardown()
        {
            base.TearDown();
            SceneManager.LoadScene("studyNotesMenu"); // Unloading the last loaded scene Assets/Resources/test_scene.unity(build index: 0), is not supported. Please use SceneManager.LoadScene()/EditorSceneManager.OpenScene() to switch to another scene.
        }

        public void ClickUI(GameObject uiElement)// so we can click on any UI element we choose
        {
            Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            Vector2 screenPosition = camera.WorldToScreenPoint(uiElement.transform.position);
            Set(mouse.position, screenPosition);
            Click(mouse.leftButton);
            //Release(mouse.leftButton); // need to release??
        }

    [UnityTest]
    public IEnumerator StringOneButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("LevelOneButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "LevelOneButton button not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("viewNotes1", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking LevelOneButton");
    }
    [UnityTest]
    public IEnumerator LevelTwoButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("LevelTwoButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "LevelTwoButton button not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("viewNotes2", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking LevelTwoButton");
    }
    [UnityTest]
    public IEnumerator LevelThreeButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("LevelThreeButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "LevelThreeButton button not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("viewNotes3", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking LevelThreeButton");
    }
    [UnityTest]
    public IEnumerator LevelFourButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("LevelFourButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "LevelFourButton button not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("viewNotes4", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking LevelFourButton");
    }
    [UnityTest]
    public IEnumerator LevelFiveButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("LevelFiveButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "LevelFiveButton button not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("viewNotes5", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking LevelFiveButton");
    }
    [UnityTest]
    public IEnumerator LevelSixButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("LevelSixButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "LevelSixButton button not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("viewNotes6", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking LevelSixButton");
    }
    
    [UnityTest]
    public IEnumerator ReturnToMenuButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("returnToMenuButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "returnToMenuButton not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("startMenu", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking returnToMenuButton");
    }
}
