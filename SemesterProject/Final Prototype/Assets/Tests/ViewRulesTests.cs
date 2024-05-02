using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement; // for loading and  restarting game
using UnityEngine.InputSystem;
using TMPro;// so we can use mouse and keyboard

public class ViewRulesTests : InputTestFixture
{
    Mouse mouse;
    Keyboard keyboard;

        public override void Setup()
        {
            SceneManager.LoadScene("viewRules");
            base.Setup();
            mouse = InputSystem.AddDevice<Mouse>();
            keyboard = InputSystem.AddDevice<Keyboard>();
        }

        public override void TearDown() // overrides inputtestfixture.teardown()
        {
            base.TearDown();
            SceneManager.LoadScene("viewRules"); // Unloading the last loaded scene Assets/Resources/test_scene.unity(build index: 0), is not supported. Please use SceneManager.LoadScene()/EditorSceneManager.OpenScene() to switch to another scene.
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
    public IEnumerator FretboardDiagramButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Button = GameObject.Find("fretboardDiagramButton");

        // Assert that the button is not null
        Assert.IsNotNull(Button, "fretboardDiagramButton not found in Intro scene");

        // Simulate a button click
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("infoFretboard", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking fretboardDiagramButton");
    }
    [UnityTest]
    public IEnumerator ReturnToMenuButtonWorks()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject selectLevelButton = GameObject.Find("returnToMenuButton");

        // Assert that the button is not null
        Assert.IsNotNull(selectLevelButton, "View rules button not found in Intro scene");

        // Simulate a button click
        selectLevelButton.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreEqual("startMenu", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking view rules button");
    }
    
}
