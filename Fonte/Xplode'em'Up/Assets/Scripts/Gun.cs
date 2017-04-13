using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	GameObject ammunition;

	void Start () {
		ammunition = Resources.Load ("Prefabs/Bullet") as GameObject;
	}

	void Update () {
		Aim ();
	}

	void Aim () {
		//transform.rotation = Quaternion.???
	}
}
