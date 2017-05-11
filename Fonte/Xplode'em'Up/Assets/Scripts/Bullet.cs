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

    private void OnTriggerEnter(Collider col) {
        //Should destroy on any collision
        if (col.transform.tag.Equals("ShieldOrc"))
        {
            Debug.Log("Acertou Shield");
       }
        if (col.transform.tag.Equals("Inimigo"))
        {
            Debug.Log("Acertou Inimigo");
            Destroy(col.gameObject);
        }
        if (col.transform.tag.Equals("Cubo"))
        {
            Debug.Log("Acertou Cubo");
        }
        if (col.transform.tag.Equals("Floor"))
        {
            Debug.Log("Acertou Floor");
        }
        if (col.transform.tag.Equals("Wall"))
        {
            Debug.Log("Acertou Floor");
        }
        Destroy(gameObject);
    }
    /* private void OnTriggerEnter(Collider col)
    {
        //Should destroy on any collision
        if (col.transform.tag.Equals("ShieldOrc"))
        {
            Debug.Log("Acertou Shield");
        }
       
        Destroy(gameObject);
    }*/

}
