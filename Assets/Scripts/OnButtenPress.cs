using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtenPress : MonoBehaviour {

	public GameObject player;
	public Button thisButton;
    public GameObject gameManager;

    void Start(){
		Button btn = thisButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		Time.timeScale = 1;
		player.GetComponent<PlayerController>().enabled = true;
		player.GetComponent<PlayerMain>().enabled = true;
        gameManager.GetComponent<PauseMenu>().enabled = true;
    }

}
