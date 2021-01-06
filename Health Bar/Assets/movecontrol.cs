
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class movecontrol : MonoBehaviour
{
    public float MoveSpeed ;
    public float rotSpeed ;
    public Animator mAnimation;
    void Start()
    {
        MoveSpeed = 0.5f;
        rotSpeed = 80;
    }
 
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mAnimation.SetBool("judge",true);
            transform.Translate(Vector3.forward*Time.deltaTime*MoveSpeed);
          
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            mAnimation.SetBool("judge",false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotSpeed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
       
    }
 
 
 
}