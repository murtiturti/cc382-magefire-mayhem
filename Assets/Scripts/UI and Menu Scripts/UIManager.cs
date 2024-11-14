using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager ui_manager;

    private Image spellIcon;
    public Sprite[] spell_sprites;

    public GameObject[] heartBars = new GameObject[6];
    public GameObject[] manaBars = new GameObject[6];

    private void Awake()
    {
        if (ui_manager == null) ui_manager = this;
        else Destroy(this);

        spellIcon = GameObject.Find("Potion Icon").GetComponent<Image>();

        for (int i = 0; i < heartBars.Length; i++)
        {
            heartBars[i] = GameObject.Find($"Health Bar {i}");
        }

        for (int i = 0; i < manaBars.Length; i++)
        {
            manaBars[i] = GameObject.Find($"Mana Bar {i}");
        }

        updateHealthBar(heartBars.Length);
        updateManaBar(manaBars.Length);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseButton();
        }
    }

    public void pauseButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void updateSpellIcon(int spell_index)
    {
        spellIcon.sprite = spell_sprites[spell_index];
    }

    public void updateHealthBar(int health)
    {
        for (int i = 0; i < heartBars.Length; i++)
        {
            if (i < health) heartBars[i].SetActive(true);
            else heartBars[i].SetActive(false);
        }
    }

    public void updateManaBar(int mana)
    {
        for (int i = 0; i < manaBars.Length; i++)
        {
            if (i < mana) manaBars[i].SetActive(true);
            else manaBars[i].SetActive(false);
        }
    }
}
