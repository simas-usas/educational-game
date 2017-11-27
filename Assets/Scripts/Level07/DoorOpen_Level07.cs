using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_Level07 : MonoBehaviour {

	public GameObject player;
	public GameObject screen;
	public bool finish = false;
	public GameManager_Level07 manager;
   

    bool doTrigger;
	bool processTrigger;

    private Animator doorAnimator;

    // Use this for initialization
    void Start () {
        doorAnimator = GetComponent<Animator>();

        doorAnimator.SetInteger("AnimState", 0);
    }

	// Update is called once per frame
	void Update () {


			doorAnimator.SetInteger("AnimState", 1);
			if (doTrigger) {
				if (Input.GetKey ("space")) {
					finish = true;
					manager.WinLevel ();
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
