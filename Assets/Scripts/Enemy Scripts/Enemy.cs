using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnim;
    public Transform playerTrans;

    private int health;

    private string state;
    private int moveSpeed = 3;
    private int awarenessDist = 40;
    private int attackDist = 15;
    private bool attacking = false;
    private float attackCooldown = 1.5f;

    void Start()
    {
        state = "idle";
        health = 2;
        enemyAnim = this.GetComponent<Animator>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (!attacking)
        {
            if (Vector3.Distance(transform.position, playerTrans.position) <= awarenessDist)
            {
                if (state == "idle" || state == "attack")
                {
                    state = "chase";
                    enemyAnim.Play("RigGob1_Run");
                }
            }

            if (Vector3.Distance(transform.position, playerTrans.position) > awarenessDist)
            {
                if (state == "chase" || state == "attack")
                {
                    state = "idle";
                    enemyAnim.Play("RigGob1_Idle");
                }
            }

            if (Vector3.Distance(transform.position, playerTrans.position) <= attackDist && state == "chase")
            {
                state = "attack";
                enemyAnim.Play("RigGob1_Idle");
            }

            if (state == "attack")
            {
                StartCoroutine(AttackPlayer());
            }

            if (state == "chase")
            {
                transform.LookAt(playerTrans);

                if (Vector3.Distance(transform.position, playerTrans.position) >= attackDist)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }
            }
        }
    }

    private IEnumerator AttackPlayer()
    {
        attacking = true;
        yield return new WaitForSeconds(attackCooldown / 2);

        // TODO: Attack player
        Debug.Log("attack");

        yield return new WaitForSeconds(attackCooldown / 2);
        attacking = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            // TODO: Fix with actual damage of projectile
            decreaseHealth(1);
        }
    }

    private void decreaseHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}