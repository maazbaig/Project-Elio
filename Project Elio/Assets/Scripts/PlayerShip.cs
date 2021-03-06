﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerShip : MonoBehaviourPun
{
    public float speed;
    private Rigidbody rb;

    public ParticleSystem boostParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            rb.velocity = transform.forward * speed * z * Time.deltaTime;

            if(z != 0)
            {
                var em = boostParticles.emission;
                em.enabled = true;
            } else
            {
                var em = boostParticles.emission;
                em.enabled = false;
            }
        }    
    }
}
