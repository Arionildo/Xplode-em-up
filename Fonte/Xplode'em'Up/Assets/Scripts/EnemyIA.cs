using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {
    private bool isTurning = false;
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

        if (!isTurning && hit.distance > maxDistance && !hit.transform.tag.Equals("Player"))
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        else {
            isTurning = true;
            transform.rotation *= Quaternion.AngleAxis(uTurn, Vector3.up);
        }
    }
}
