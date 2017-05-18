using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   
	public float x = 5;
	public float y = 1;
    public float maxSpeed = 100 ;
    public float gravity = -9;
    public float forca_cima, forca_lado;
    Vector3 forca_movimento, forca_convertida;

   

    private CharacterController cc;

    void Start () {    

        cc = GetComponent<CharacterController>();

    }

	void Update () {

        if (transform.position.y <= -20)
            transform.position = new Vector3 (0,1,0);
         
        Movement();

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
        
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        
        if (col.transform.tag.Equals("Inimigo") || col.transform.tag.Equals("ShieldOrc"))
        {
            Debug.Log("Colidiu");
            GameManager.ResetStage();
        }
    }

}
