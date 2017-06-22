using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private AudioSource audioSource;

    public float speed = 10f;
    public float lifetime = 1f;
	public float damage = 30;
    public GameObject explosao;
    public AudioClip somHit;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, lifetime);
        
	}

    private void OnTriggerEnter(Collider col) {
        Instantiate(explosao, transform.position, transform.rotation);
        audioSource.clip = somHit;
        audioSource.Play();
        Destroy(gameObject);
    }

}
