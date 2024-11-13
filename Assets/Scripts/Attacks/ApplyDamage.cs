using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    [SerializeField] private Attack attack;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // TODO: Prevent the player from hurting themselves
            var healthComp = other.gameObject.GetComponent<Health>();
            healthComp.DecreaseHealth(attack.DamageVal());
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            var healthComp = other.gameObject.GetComponent<Health>();
            healthComp.DecreaseHealth(attack.DamageVal());
        }
    }
}
