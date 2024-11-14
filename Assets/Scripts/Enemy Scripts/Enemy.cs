using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnim;
    public Transform playerTrans;

    private string state;
    public int moveSpeed = 3;
    public int awarenessDist = 20;
    public int attackDist = 10;
    private bool attacking = false;
    public float attackCooldown = 1.5f;

    void Start()
    {
        state = "idle";
        enemyAnim = this.GetComponent<Animator>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (!attacking)
        {
            if (Vector3.Distance(transform.position, playerTrans.position) <= awarenessDist && state == "idle")
            {
                state = "chase";
                enemyAnim.SetBool("idle", false);
            }

            if (Vector3.Distance(transform.position, playerTrans.position) > awarenessDist && state == "chase")
            {
                state = "idle";
                enemyAnim.SetBool("idle", true);
            }

            if (Vector3.Distance(transform.position, playerTrans.position) <= attackDist && state == "chase")
            {
                state = "attack";
                enemyAnim.SetBool("idle", true);
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
}