using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public static Mana mana_instance;

    public int mana;
    public int manaMax;

    private void Awake()
    {
        if (mana_instance == null) mana_instance = this;
        else Destroy(this);

        manaMax = 10;
        mana = manaMax;
    }

    public void DecreaseMana(int mana_loss)
    {
        mana = Mathf.Max(mana - mana_loss, 0);
        UIManager.ui_manager.updateManaBar(mana);
    }

    public void IncreaseMana(int extra_mana)
    {
        mana = Mathf.Min(mana + extra_mana, manaMax);
        UIManager.ui_manager.updateManaBar(mana);
    }
}
