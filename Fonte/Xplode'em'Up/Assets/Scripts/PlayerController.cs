﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   
	public float x = 1000;
	public float y = 500;
    public float maxSpeed = 100 ;
    public float gravity = 0;
    private float forca_cima, forca_lado;
    Vector3 forca_movimento, forca_convertida;

   
	float maxDistanceToGround;
    private CharacterController cc;

    void Start () {

        cc = GetComponent<CharacterController>();

    }

	void Update () {

        if (transform.position.y <= -20) transform.position = new Vector3 (0,1,0);
        cc.Move(new Vector3(0, gravity* Time.deltaTime, 0));
       
        Movement(); 
    }

    void Movement()
    {  
        
            
            x = Input.GetAxis("Horizontal")*maxSpeed* Time.deltaTime;
        // y = Input.GetAxis("Vertical")*maxSpeed *Time.deltaTime;
        if (cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W)) forca_cima = y;
        }
        if (!cc.isGrounded)
        {
            forca_cima += gravity * Time.deltaTime;
        }

        forca_movimento = new Vector3(x, forca_cima, 0);
            forca_convertida = transform.TransformDirection(forca_movimento);
            cc.Move(forca_convertida);
        
    }

	

}
