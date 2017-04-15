using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject ammunition;
    public Transform bulletSpawner;

	void Update () {
		Aim ();
        Shoot();
	}

    private void Shoot() {
        if (Input.GetMouseButtonDown(0))
            Instantiate(ammunition, bulletSpawner.position, bulletSpawner.rotation);
    }

    private void Aim () {
        //Calculates where the gun should aim accordingly to the mouse position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        transform.LookAt(mousePosition);
    }
}
