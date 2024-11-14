using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnPoint : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(6, 6);
    }

    public void Focus(Vector3 point)
    {
        transform.LookAt(point);
    }

    public void Shoot(float speed, bool gravity)
    {
        rb.velocity = speed * rb.transform.forward;
        rb.useGravity = gravity;
        StartCoroutine(DestroyAttack());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // TODO: Damage enemy

            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Environment") || other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator DestroyAttack()
    {
        // Destroys attack after 10 seconds to improve performance
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
