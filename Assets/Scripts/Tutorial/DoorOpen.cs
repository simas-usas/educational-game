using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	public GameObject player;

	public GameObject screen;
	public bool finish = false;
	public GameManager manager;

	bool doTrigger;
	bool processTrigger;
	string processName;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		screen = GameObject.Find ("Canvas").transform.Find ("Interface").gameObject.transform.Find("Enter Button").gameObject;
			
		processTrigger = screen.GetComponent<ProcessInformation> ().triggerDoor;
		processName = screen.GetComponent<ProcessInformation> ().valueName;


		if (processTrigger && doTrigger && processName == "doorOpen") {
			if (Input.GetKey ("space")) 
			{			
				finish = true;
				manager.WinLevel ();
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
