using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorScreen_Level07 : MonoBehaviour {


    public GameObject processText;
    public Text errorText; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        GetComponent<Text>().text = processText.GetComponent<ProcessInformation_Level07>().error.text;
        

	}
}
