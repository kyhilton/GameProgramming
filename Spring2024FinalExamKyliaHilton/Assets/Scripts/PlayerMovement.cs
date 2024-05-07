using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float movement = 6.0f;
    public float speed = 2.0f;
    private float scale;
    private int score;

    private bool pause = false;
    public Text pausedmessage;
    public Text nameText;
    public Text scoreText;
    public Text sizeText;
    public Slider slider;
    public Dropdown ColorDropdown;

    public Material Pink;
    public Material Green;
    public Material Blue;


    void Start()
    {
        nameText.text = GameObject.Find("Main Camera").GetComponent<manageButtons>().RetrievePlayerName();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.P))
        {
            Pause();
        }
    }
    private void MoveLeft()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.left);
    }

    public void MoveRight()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.right);
    }

    private void MoveForward()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.forward);
    }

    private void MoveBack()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.back);
    }

    private void Pause()
    {
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;
            pausedmessage.text = "";
        }
        else
        {
            pause = true;
            Time.timeScale = 0;
            pausedmessage.text = "Paused";
        }
    }

    public void OnValueChanged()
    {
        scale = slider.value;
        this.transform.localScale = new Vector3(scale, scale, scale);
        this.transform.localPosition = new Vector3(transform.localPosition.x, 0.5f * scale, transform.localPosition.z);
        sizeText.text = "Player Size: " + Convert.ToString(scale);
    }
    public void ChooseColor()
    {
        switch (ColorDropdown.value)
        {
            case 1:
                this.GetComponent<MeshRenderer>().material = new Material(Pink);
                break;
            case 2:
                this.GetComponent<MeshRenderer>().material = new Material(Blue);
                break;
            default: 
                this.GetComponent<MeshRenderer>().material = new Material(Green);
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("target"))
        {
            score++;
            UpdateScoreText();
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("PlayerScore", score);

        }
        else if (score == 5)
        {
            GameObject.Find("Main Camera").GetComponent<HighScoreControl>().SendScoreBtn();
            GameObject.Find("Main Camera").GetComponent<manageButtons>().GameToExit();
        }

    }
    private void UpdateScoreText()
    {
        // Update the UI Text with the current score
        scoreText.text = score.ToString();
    }
}
