using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnPoint : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Focus(Vector3 point)
    {
        transform.LookAt(point);
    }

    public void Shoot(float speed)
    {
        rb.velocity = speed * rb.transform.forward;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //TODO: Damage enemy
        }
    }
}
