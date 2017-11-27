using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Collider2D rightBox;
	public Collider2D leftBox;

	public GameObject screen;
	public bool tileTrigger;
    public bool tileDistTrigger;

    public int tileSpeed;
	public int tileDistance;

	
	// Update is called once per frame
	void Update () {

		screen = GameObject.Find ("Canvas").transform.Find ("Interface").gameObject.transform.Find("Enter Button").gameObject;
		tileTrigger = screen.GetComponent<ProcessInformation_Level07> ().triggerTile;
        tileDistTrigger = screen.GetComponent<ProcessInformation_Level07>().triggerTilePlat;
        tileDistance = 10 * (screen.GetComponent<ProcessInformation_Level07> ().playerForValue);
		tileSpeed = 10 * (screen.GetComponent<ProcessInformation_Level07> ().triggerSpeed);

		if (tileTrigger && tileDistTrigger) {
			transform.position = new Vector3 (-Mathf.PingPong (tileSpeed * Time.time, tileDistance), transform.position.y, transform.position.z);
		}

		OnRightCollision (rightBox);
		OnLeftCollision (leftBox);
	}

	void OnRightCollision (Collider2D hit)
	{
		if (hit.transform.gameObject.name == "RightBox") {
			transform.position = new Vector3(-Mathf.PingPong(6*Time.time, tileDistance), transform.position.y, transform.position.z);
		}

	}

	void OnLeftCollision (Collider2D hit)
	{
		if (hit.transform.gameObject.name == "LeftBox") {
			transform.position = new Vector3(Mathf.PingPong(6*Time.time, tileDistance), transform.position.y, transform.position.z);
		}

	}
}
