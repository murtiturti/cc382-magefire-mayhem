using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    [SerializeField] private List<Attack> _spells = new List<Attack>();
    private int _spellIndex = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(_spells[_spellIndex].Cast(transform));
        }
    }
}
