using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EthanCharacter : MonoBehaviour
{
  private Vector3 startPosition;
  private Animator animator;
  public Rigidbody rb;
  public Transform characterTransform;
  public float speed = 10f;
  private float maxSpeed;
  public float jumpForce = 6f;
  public float turbo = 30f;
  // [Range(-2, 2)] public float speed = 0;
  private bool jumping = false;
  // private float lastYFrame = 0;

  // enum AnimationParameters
  // {
  //   forwardMovement
  // }

  void Awake()
  {
    animator = GetComponent<Animator>();
    startPosition = this.transform.position;
    maxSpeed = speed;
  }

  void Update()
  {
  }

  void FixedUpdate()
  {
    float forwardMovement = Input.GetAxis("Horizontal");
    jumping = Vector3.Dot(rb.velocity, Vector3.up) < 0.1;

    if (jumping && Input.GetKeyDown(KeyCode.Space))
    {
      rb.velocity = Vector3.up * jumpForce;
    }

    speed = (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) ? turbo : maxSpeed;

    if (forwardMovement != 0)
    {
      float y = (forwardMovement < 0) ? -90 : 90;
      Vector3 input = new Vector3(0, y, 0);
      characterTransform.eulerAngles = input;
      rb.velocity = new Vector3(speed * forwardMovement, rb.velocity.y, 0);
    }
    else
    {
      rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
    }
    
    animator.SetFloat("Speed", Mathf.Abs(forwardMovement));
    
    // if (jump) rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
    //
    // float horizontal = Input.GetAxis("Horizontal");
    // jump = (Input.GetKeyDown(KeyCode.Space)) ? true : false;
    //
    // //horizontal = speed;
    //
    // //Set character rotation
    // float y = (horizontal < 0) ? -90 : 90;
    // Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
    // transform.rotation = newRotation;
    //
    // //Set character animation
    // animator.SetFloat("Speed", Mathf.Abs(horizontal));
    //
    // //move character
    // transform.Translate(  Time.deltaTime * -horizontal * modifier * transform.right);
  }

  public void resetEthan()
  {
    this.transform.position = startPosition;
    
  }
  
}
