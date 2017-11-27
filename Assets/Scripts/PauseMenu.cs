using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;
    public GameObject player;
    public SceneFader fader;
    public string currentScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            Toggle();

        }
    }

    public void Toggle() {


        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;

            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerMain>().enabled = false;

        }
        else {
            Time.timeScale = 1f;

            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<PlayerMain>().enabled = true;
        }

    }

    public void Retry() {
        Toggle();
        
        fader.FadeTo(currentScene);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void Menu()
    {
        Toggle();

        fader.FadeTo("LevelSelect");
    }
}
