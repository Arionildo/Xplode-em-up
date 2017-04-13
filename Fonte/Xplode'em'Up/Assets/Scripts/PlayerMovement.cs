﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveForce = 1000;
	public float jumpForce = 500;
	Rigidbody rb;
	float maxDistanceToGround;

	void Start () {
		rb = GetComponent<Rigidbody> ();

		/* FOR JUMP ACTION!
		 * Sets the max distance the character can be from the ground (with an offset)
		*/
		maxDistanceToGround = GetComponent<Collider> ().bounds.extents.y + 0.1f;
	}

	void Update () {
		Move ();
		Jump ();
	}

	void Move () {
		//Sets the speed according to the given movement force
		float speed =  moveForce * Time.deltaTime;

		//Applies force in a given direction (if not set by player, anything happens) to move the character with its previously calculated speed
		rb.AddForce (Input.GetAxis ("Horizontal") * speed , 0, 0);
	}

	void Jump () {
		//Checks if the player intends to jump AND if the character isn't already jumping (may change when Double Jump is implemented)
		if (Input.GetKeyDown(KeyCode.W) && IsGrounded ())
			rb.AddForce (0 , jumpForce, 0);
	}

	bool IsGrounded () {
		//Returns true when reached the given max distance
		return Physics.Raycast(transform.position, -Vector3.up, maxDistanceToGround);
	}
}
