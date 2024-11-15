using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnim;
    public Transform playerTrans;

    [SerializeField] private AudioClip goblin_hit;

    [SerializeField] private int health;

    private string state;
    private int moveSpeed = 3;
    private int awarenessDist = 40;
    private int attackDist = 15;
    private bool attacking = false;
    private float attackCooldown = 1.5f;

    [SerializeField] private Attack fireballAttack;

    private AudioSource _source;

    void Start()
    {
        state = "idle";
        _source = GetComponent<AudioSource>();
        //health = 2;
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

        StartCoroutine(fireballAttack.Cast(transform));

        yield return new WaitForSeconds(fireballAttack.CooldownTime());
        attacking = false;
    }
    
    /* DO NOT USE THIS DAMAGE IS HANDLED IN APPLY DAMAGE.CS
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            // TODO: Fix with actual damage of projectile
            decreaseHealth(1);
        }
    }
    */

    public void decreaseHealth(int damage)
    {
        Sound_Effects.Instance.Play_Sound_Effects(goblin_hit, transform, 1f);
        health -= damage;

        if (health <= 0)
        {
            state = "idle";
            Destroy(this.gameObject);
        }
    }
}