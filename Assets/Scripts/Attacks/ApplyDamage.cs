using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    [SerializeField] private Attack attack;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            other.gameObject.GetComponent<Enemy>().decreaseHealth(attack.DamageVal());
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Health.health_instance.DecreaseHealth(attack.DamageVal());
            Destroy(this.gameObject);
        }

        if (!other.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
        }
    }
}
