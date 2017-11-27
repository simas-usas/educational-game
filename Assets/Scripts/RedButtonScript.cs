﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonScript : MonoBehaviour {

    public GameObject screen;
    public bool doRedTrigger;
    public Animator buttonAnimator;

    void Update()
    {
        bool redButton = screen.GetComponent<ProcessInformation_Level05>().redButton;

        if (redButton)
        {
            buttonAnimator.SetInteger("AniState", 2);
        }
    }

    void OnTriggerEnter2D (Collider2D col){
		doRedTrigger = true;
	}

	void OnTriggerExit2D (Collider2D col){
		doRedTrigger = false;
	}
}