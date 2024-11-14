using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    private Transform playerTrans;
    private Rigidbody _rb;
    private ParticleSystem attackPS;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attackPS = this.gameObject.GetComponentInChildren<ParticleSystem>();
    }

    public void Shoot(float speed)
    {
        _rb.velocity = speed * (playerTrans.position - transform.position).normalized;
        attackPS.Play();
        //StartCoroutine(DestroyAttack());
    }

    /*
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
    */
    
    public IEnumerator DestroyAttack()
    {
        // Destroys attack after 10 seconds to improve performance
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
