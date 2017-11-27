using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

	public GameObject screen;
	bool processTrigger;
	string processName;
	bool doTrigger;

	public bool triggerDoor = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		screen = GameObject.Find ("Canvas").transform.Find ("Interface").gameObject.transform.Find("Enter Button").gameObject;

		processTrigger = screen.GetComponent<ProcessInformation_Level04> ().triggerButton;
		processName = screen.GetComponent<ProcessInformation_Level04> ().valueName;

		if (processTrigger && doTrigger && processName == "buttonPressed") {
			if (Input.GetKey ("space")) {			
				triggerDoor = true;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		doTrigger = true;
	}

	void OnTriggerExit2D (Collider2D col){
		doTrigger = false;
	}


}
