using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AudioSource jump;
    public Rigidbody rb;

    void Start()
    {
        jump = GetComponent<AudioSource>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 300);
            jump.Play();
        }
    }

}