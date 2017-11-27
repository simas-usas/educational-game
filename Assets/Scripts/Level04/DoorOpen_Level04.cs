﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_Level04 : MonoBehaviour {

	public GameObject player;
	public GameObject button;
	public GameObject screen;
	public bool finish = false;
	public GameManager_Level04 manager;
   

    bool doTrigger;
	bool processTrigger;
	string processName;

    private Animator doorAnimator;

    // Use this for initialization
    void Start () {
        doorAnimator = GetComponent<Animator>();

        doorAnimator.SetInteger("AnimState", 0);
    }

	// Update is called once per frame
	void Update () {

		processTrigger = button.GetComponent<ButtonPress> ().triggerDoor;
		processName = screen.GetComponent<ProcessInformation_Level04> ().valueDoName;


		if (processTrigger)
        {
			doorAnimator.SetInteger("AnimState", 1);
			if (doTrigger && processName == "doorOpen") {
				if (Input.GetKey ("space")) {
					finish = true;
					manager.WinLevel ();
				}
			}
	    }

	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        doTrigger = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        doTrigger = false;
    }

}