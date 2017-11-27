using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen_Level02 : MonoBehaviour {

	public GameObject player;
	public GameObject inActiveScreen;
	public GameObject screen;
	public bool finish = false;
	public GameManager_Level02 manager;
    
	bool processTrigger;
    bool doTrigger;

    private Animator doorAnimator;

    // Use this for initialization
    void Start () {
        doorAnimator = GetComponent<Animator>();

        doorAnimator.SetInteger("AnimState", 1);
    }

	// Update is called once per frame
	void Update () {

		screen = GameObject.Find ("Canvas").transform.Find ("Interface").gameObject.transform.Find("Enter Button").gameObject;
		

        if (doTrigger)
        {
            if (Input.GetKey("space"))
            {
                finish = true;
                manager.WinLevel();
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
