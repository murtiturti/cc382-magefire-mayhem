using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager ui_manager;

    private Image spellIcon;
    public Sprite[] spell_sprites;

    private void Awake()
    {
        if (ui_manager == null)
        {
            ui_manager = this;
        }
        else
        {
            Destroy(this);
        }

        spellIcon = GameObject.Find("Potion Icon").GetComponent<Image>();
    }

    public void pauseButton()
    {
        // TODO: Fix
    }

    public void updateSpellIcon(int spell_index)
    {
        spellIcon.sprite = spell_sprites[spell_index];
    }
}
