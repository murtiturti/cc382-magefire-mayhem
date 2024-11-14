using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private string pickup_type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pickup_type == "health")
            {
                Health.health_instance.IncreaseHealth(2);
            }
            if (pickup_type == "mana")
            {
                Mana.mana_instance.IncreaseMana(6);
            }
        }

        Destroy(this.gameObject);
    }
}
