using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public GameObject screen;

	public double xBoxSize = 1;
    public double yBoxSize = 1;

    // Use this for initialization
    void Start () {
		//transform.localScale = new Vector3 (0.1f, 0.5f, 1f);
	}

	void Update (){

	}
	
	// Update is called once per frame
	public void ButtonPressed () {
		screen = GameObject.Find ("Canvas").transform.Find ("Interface").gameObject.transform.Find("Enter Button").gameObject;
		
        xBoxSize = screen.GetComponent<ProcessInformation_Level02> ().playerNumberX;
        yBoxSize = screen.GetComponent<ProcessInformation_Level02> ().playerNumberY;

        
        if (screen.GetComponent<ProcessInformation_Level02> ().xAxisBox) {
            Vector3 xScale = transform.localScale;
            xScale[0] = (float)xBoxSize * 0.1f;
            transform.localScale = xScale;

            //transform.localScale = new Vector3((float)xBoxSize * 0.1f, 0.1f, 1f);
            //transform.position = new Vector3 (0, 5, 0);
        }

        if (screen.GetComponent<ProcessInformation_Level02>().yAxisBox)
        {
            Vector3 yScale = transform.localScale;
            yScale[1] = (float)yBoxSize * 0.1f;
            transform.localScale = yScale;


            //transform.localScale = new Vector3(0.1f, (float)yBoxSize * 0.1f, 1f);
            transform.position = new Vector3(0, ((float)-34.88 + ((float)yBoxSize-1) * 5f), 0);
        }

        /*

        if (screen.GetComponent<ProcessInformation_Level02>().yAxisBox || screen.GetComponent<ProcessInformation_Level02>().xAxisBox)
        {

            transform.localScale = new Vector3((float)xBoxSize * 0.1f, (float)yBoxSize * 0.1f, 1f);
           
            transform.position = new Vector3(0, 5, 0);
        }
        */

    }

     

}
