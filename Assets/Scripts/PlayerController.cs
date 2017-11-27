using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2();


	public bool jump;

	//public float moveSpeed;
	//public float jumpPower;

	//private Animator animator;
	//private Rigidbody2D body2D;

	// Use this for initialization
	void Start () {
	//	animator = GetComponent<Animator> ();
	//	body2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
			animator.SetInteger ("AnimState", 1);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (-Vector2.right * moveSpeed * Time.deltaTime);
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger ("AnimState", 0);
		}

		body2D = GetComponent<Rigidbody2D> ();
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			body2D.AddForce (Vector2.up * jumpPower);
		}
		*/


		moving.x = 0;
		moving.y = 0;

		if (Input.GetKey ("right")) {
			moving.x = 1;
		} else if (Input.GetKey ("left")) {
			moving.x = -1;
		}

		/*
		if (Input.GetKeyDown ("up")) {
			jump = true;
		} else {
			jump = false;
		}

		*/


	//	} else if (Input.GetKey ("down")) {
		//		moving.y = -1; }

	


	}





}
