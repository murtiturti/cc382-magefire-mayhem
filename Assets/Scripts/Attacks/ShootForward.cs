using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    private Transform playerTrans;
    private Rigidbody _rb;
    private ParticleSystem attackPS;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attackPS = this.gameObject.GetComponentInChildren<ParticleSystem>();
    }

    public void Shoot()
    {
        _rb.velocity = speed * playerTrans.forward;
        attackPS.Play();
        StartCoroutine(DestroyAttack());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // TODO: Damage if enemy

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Environment") || other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    
    public IEnumerator DestroyAttack()
    {
        // Destroys attack after 15 seconds to improve performance
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
