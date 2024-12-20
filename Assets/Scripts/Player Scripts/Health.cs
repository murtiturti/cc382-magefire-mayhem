using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health health_instance;

    public int health;
    public int healthMax;

    private void Start()
    {
        if (health_instance == null) health_instance = this;
        else Destroy(this);

        healthMax = 6;
        health = healthMax;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // TODO: player died
            Time.timeScale = 0;
            UIManager.ui_manager.OnLose();
        }

        UIManager.ui_manager.updateHealthBar(health);
    }

    public void IncreaseHealth(int heal)
    {
        health = Mathf.Min(health + heal, healthMax);
        UIManager.ui_manager.updateHealthBar(health);
    }
}
