using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    [SerializeField] private List<Attack> _spells = new List<Attack>();
    private int spell_index = 0;

    private void Update()
    {
        // Switch Spell
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spell_index = 0;
            UIManager.ui_manager.updateSpellIcon(spell_index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spell_index = 1;
            UIManager.ui_manager.updateSpellIcon(spell_index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spell_index = 2;
            UIManager.ui_manager.updateSpellIcon(spell_index);
        }

        // Attack
        if (Input.GetMouseButtonDown(0))
        {
            // TODO: fix once each spell is implemented
            spell_index = 0;

            StartCoroutine(_spells[spell_index].Cast(transform));
        }
    }
}
