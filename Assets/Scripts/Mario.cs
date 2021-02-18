using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{

    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Stone" || other.gameObject.name == "Rock")
        {
            Debug.Log(this.gameObject.name + " has hit a " + other.gameObject.name);
        }
    }
}
