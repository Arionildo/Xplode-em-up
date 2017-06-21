using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxHP = 100;
    public float currentHP = 100;
	public float x = 5;
	public float y = 1;
    public float maxSpeed = 100 ;
    public float gravity = -9;
    public float forca_cima, forca_lado;
    Vector3 forca_movimento, forca_convertida;
    public GameObject modeloPlayer;
    public Animator animPlayer;
    public GameObject colunaPlayer;
    public GameObject gun;
    public Vector3 colunaRot;
    
    private CharacterController cc;

    void Start () {    

        cc = GetComponent<CharacterController>();
        currentHP = maxHP;
    }

	void Update () {
        Movement();

		if (!IsAlive() || transform.position.y <= -20)
            GameManager.ResetStage();
    }

    private void LateUpdate()
    {
        //Virar modelo e coluna do player
        if (gun.transform.localRotation.y < 0)
        {
            modeloPlayer.transform.eulerAngles = new Vector3(0, 270, 0);
            colunaRot.z = -gun.transform.eulerAngles.x + 90;
            colunaRot.x = 180f;
        }
        else
        {
            modeloPlayer.transform.eulerAngles = new Vector3(0, 90, 0);
            colunaRot.z = -gun.transform.eulerAngles.x - 90;
            colunaRot.x = 0f;
        }

        colunaRot.y = 0f;
        colunaPlayer.transform.eulerAngles = colunaRot;
    }

    private bool IsAlive() {
        return currentHP > 0 ? true : false;
    }

    void Movement()
    {  
        forca_lado = Input.GetAxis("Horizontal")*x* Time.deltaTime;

        if (!cc.isGrounded)
            forca_cima += gravity * Time.deltaTime;
        else forca_cima = -1;
        if (Input.GetKeyDown(KeyCode.W)&& (cc.isGrounded))
                forca_cima= y;
           
            
        forca_movimento = new Vector3(forca_lado, forca_cima, 0);
		forca_convertida = transform.TransformDirection(forca_movimento);
		cc.Move(forca_convertida);

        CallAnimations();
    }

    private void CallAnimations()
    {
        if (forca_lado != 0)
            animPlayer.SetTrigger("Run");
        else
            animPlayer.SetTrigger("Idle");
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        
        if (col.transform.tag.Equals("Inimigo") || col.transform.tag.Equals("ShieldOrc"))
        {
            Debug.Log("Colidiu");
            currentHP -= 5;
        }
    }

}
