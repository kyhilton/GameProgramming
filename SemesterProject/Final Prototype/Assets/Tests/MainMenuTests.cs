using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement; // for loading and  restarting game
using UnityEngine.InputSystem;
using TMPro;// so we can use mouse and keyboard

public class MainMenuTests : InputTestFixture
{
    Mouse mouse;
    Keyboard keyboard;

        public override void Setup()
        {
            SceneManager.LoadScene("startMenu");
            base.Setup();
            mouse = InputSystem.AddDevice<Mouse>();
            keyboard = InputSystem.AddDevice<Keyboard>();
        }

        public override void TearDown() // overrides inputtestfixture.teardown()
        {
            base.TearDown();
            SceneManager.LoadScene("startMenu"); // Unloading the last loaded scene Assets/Resources/test_scene.unity(build index: 0), is not supported. Please use SceneManager.LoadScene()/EditorSceneManager.OpenScene() to switch to another scene.
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
    public IEnumerator SelectLevelOpensLevelMenu()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject selectLevelButton = GameObject.Find("selectLevelButton");

        // Assert that the button is not null
        Assert.IsNotNull(selectLevelButton, "Select level button not found in Intro scene");

        // Simulate a button click
        selectLevelButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("levelSelect", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking Select Level button");
    }
    [UnityTest]
    public IEnumerator ViewRulesOpensViewRules()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject selectLevelButton = GameObject.Find("viewRulesButton");

        // Assert that the button is not null
        Assert.IsNotNull(selectLevelButton, "View rules button not found in Intro scene");

        // Simulate a button click
        selectLevelButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("viewRules", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking view rules button");
    }
    [UnityTest]
    public IEnumerator StudyNotesOpensStudyNotes()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject selectLevelButton = GameObject.Find("studyNotesButton");

        // Assert that the button is not null
        Assert.IsNotNull(selectLevelButton, "study notes button not found in Intro scene");

        // Simulate a button click
        selectLevelButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("studyNotesMenu", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking study notes button");
    }
}
