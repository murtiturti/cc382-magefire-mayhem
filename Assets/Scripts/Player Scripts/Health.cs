using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int healthMax;

    private void Start()
    {
        healthMax = 100;
        health = healthMax;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // TODO: player died
        }
    }

    public void IncreaseHealth(int heal)
    {
        health = Mathf.Max(health + heal, healthMax);
    }
}
