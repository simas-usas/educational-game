using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

	public float speed = 250f;
	public Vector2 maxVelocity = new Vector2 (60, 100);
	public float jetSpeed = 7500f;
	public bool standing;
	public float standingThreshold = 4f;
	public float airSpeedMultiplier = .3f;

	public bool isGrounded;

	private Rigidbody2D body2D;
	private SpriteRenderer renderer2D;
	private PlayerController controller;
	private Animator animator;



	// Use this for initialization
	void Start () {
		body2D = GetComponent<Rigidbody2D> ();
		renderer2D = GetComponent<SpriteRenderer> ();
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var absVel_X = Mathf.Abs (body2D.velocity.x);
		var absVel_Y = Mathf.Abs (body2D.velocity.y);

		var forceX = 0f;
		var forceY = 0f;

		if (absVel_Y <= standingThreshold) {
			standing = true;
		} else { 
			standing = false;

		}

		if (controller.moving.x != 0 ) {
			if (absVel_X < maxVelocity.x) {
				var newSpeed = speed * controller.moving.x;
					
				forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);	
				renderer2D.flipX = forceX < 0;

			}
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger ("AnimState", 0);
		}


		if (controller.jump && standing)  {

			if (absVel_Y < maxVelocity.y) {
				forceY = jetSpeed;

			}
			animator.SetInteger ("AnimState", 2);
		} else if (absVel_Y > 0 ) {

			animator.SetInteger ("AnimState", 2);
			//standing = false;
		} else {
			standing = false;
		}



		body2D.AddForce(new Vector2(forceX, forceY));



	}

	void OnCollisionStay(Collision collisionInfo){
		isGrounded = true;
	}

	void OnCollssionExit(Collision collisionInfo){
		isGrounded = false;
	}

}
