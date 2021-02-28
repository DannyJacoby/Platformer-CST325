using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaEnemy : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    private int polarity = 1;
    private float startingY;
    private float startingZ;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10.0f;
        startingY = this.transform.position.y - 0.5f;
        startingZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * polarity * speed;
        this.transform.position = new Vector3(this.transform.position.x, startingY, startingZ);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Rock") && !other.gameObject.CompareTag("Coin"))
        {
            polarity *= -1;
        }
    }
}
