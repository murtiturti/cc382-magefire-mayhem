using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    [SerializeField] private Attack attack;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            var healthComp = other.gameObject.GetComponent<Health>();
            healthComp.DecreaseHealth(attack.DamageVal());
        }
    }
}
