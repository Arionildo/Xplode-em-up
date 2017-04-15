using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 10f;
    public float lifetime = 1f;

	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, lifetime);
	}

    private void OnCollisionEnter(Collision col) {
        //Should destroy on any collision
        Destroy(gameObject);
    }
}
