using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialogue : MonoBehaviour {

    public GameObject dialogueScreen;
    public Dialogue dialeg;
    public GameObject player;
    public Button yourButton;
    private bool butOn;
    private Button btn;

    void Start()
    {
       btn = yourButton.GetComponent<Button>();
       
       butOn = false;
    }

    void Update() {    

    if (butOn == false)
        {
            btn.onClick.AddListener(Toggle);
            
        }

        if (butOn == true) {
            btn.onClick.AddListener(ToggleOff);

        }

    }
    
    private void Toggle() {

       
        dialogueScreen.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerMain>().enabled = false;

        butOn = true;

    }

    private void ToggleOff()
    {
        dialogueScreen.SetActive(false);
                   

        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerMain>().enabled = true;

        butOn = false;

    }


    /*
    Time.timeScale = 0;
    dialogueScreen.SetActive(true);




    player.GetComponent<PlayerController>().enabled = false;
    player.GetComponent<PlayerMain>().enabled = false;
    gameManager.GetComponent<PauseMenu>().enabled = false;
    */



}
