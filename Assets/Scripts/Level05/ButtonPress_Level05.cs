using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress_Level05 : MonoBehaviour {

	public GameObject screen;
	bool processTriggers;
	//bool processBlueTrigger;
	string processName;
	bool doTrigger;
	public RedButtonScript RedButton;

    public bool triggerDoorBlue = false;
    public bool triggerDoorRed = false;
    public bool triggerDoor = false;

    public Animator buttonAnimator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		screen = GameObject.Find ("Canvas").transform.Find ("Interface").gameObject.transform.Find("Enter Button").gameObject;

		processTriggers = screen.GetComponent<ProcessInformation_Level05> ().triggerButtons;
		//processBlueTrigger = screen.GetComponent<ProcessInformation_Level05> ().triggerBlueButton;

		//processName = screen.GetComponent<ProcessInformation_Level05> ().valueName;

		
           

		bool blueButton = screen.GetComponent<ProcessInformation_Level05> ().blueButton;

        if (blueButton) {
            buttonAnimator.SetInteger("AniState", 1);
        }



        if (processTriggers && doTrigger) {
                if (Input.GetKey("space")) {
                    triggerDoorBlue = true;        
            }
        }
        else if (processTriggers && RedButton.doRedTrigger) {
                if (Input.GetKey("space"))
                {
                    triggerDoorRed = true;
                }            
        }

        if (triggerDoorBlue && triggerDoorRed) {
            triggerDoor = true;
        }



	}

	void OnTriggerEnter2D (Collider2D col){
		doTrigger = true;
	}

	void OnTriggerExit2D (Collider2D col){
		doTrigger = false;
	}


}
