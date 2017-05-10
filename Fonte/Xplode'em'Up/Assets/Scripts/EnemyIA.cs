using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {
    private float uTurn = 180;
    public float maxDistance = 3;
    public float movespeed = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Patrol();
	}

    private void Patrol() {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.right, out hit);

		//Will flip his own direction when next to an obstacle, unless it's facing the Player
        if (hit.distance > maxDistance || hit.transform.tag.Equals("Player"))
			transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        else
			transform.eulerAngles += new Vector3(0, uTurn, 0);
    }

	private void OnCollisionEnter(Collision col) {
		if (col.transform.tag.Equals("Player"))
			GameManager.ResetStage();
	}
}
