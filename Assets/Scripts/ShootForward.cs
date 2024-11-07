using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        _rb.velocity = speed * _rb.transform.forward;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        // TODO: Damage if enemy
    }
}
