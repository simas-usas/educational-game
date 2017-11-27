using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorScreen : MonoBehaviour {


    public GameObject processText;
    public Text errorText; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        GetComponent<Text>().text = processText.GetComponent<ProcessInformation>().error.text;
        

	}
}
