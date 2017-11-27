using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScreen : MonoBehaviour {

	public GameObject player;
	public GameObject inputScreen;
    public GameObject gameManager;

	bool inTrigger;

	void Update(){
		if(inTrigger){
			if(Input.GetKey("space")){
				Time.timeScale = 0;
				inputScreen.SetActive (true);
				player.GetComponent<PlayerController>().enabled = false;	
				player.GetComponent<PlayerMain>().enabled = false;
                gameManager.GetComponent<PauseMenu>().enabled = false;
            }
		}
	
	}


	void OnTriggerEnter2D (Collider2D col){
		inTrigger = true;
	}

	void OnTriggerExit2D (Collider2D col){
		inTrigger = false;
	}

}
