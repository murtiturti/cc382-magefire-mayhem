using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager ui_manager;

    private TextMeshProUGUI hotKeyText1;
    private TextMeshProUGUI hotKeyText2;

    private Image mainSpellIcon;
    private Image miniSpellIcon1;
    private Image miniSpellIcon2;
    public Sprite[] spell_sprites;

    public GameObject[] heartBars = new GameObject[6];
    public GameObject[] manaBars = new GameObject[6];

    public GameObject winText, failText, resetButton;

    private void Awake()
    {
        if (ui_manager == null) ui_manager = this;
        else Destroy(this);

        mainSpellIcon = GameObject.Find("Main Potion Icon").GetComponent<Image>();
        miniSpellIcon1 = GameObject.Find("Mini Potion Icon 1").GetComponent<Image>();
        miniSpellIcon2 = GameObject.Find("Mini Potion Icon 2").GetComponent<Image>();
        hotKeyText1 = GameObject.Find("Hot Key Text 1").GetComponent<TextMeshProUGUI>();
        hotKeyText2 = GameObject.Find("Hot Key Text 2").GetComponent<TextMeshProUGUI>();

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
        updateSpellIcon(0);
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
        int left_spell = (spell_index + 1) % 3;
        int right_spell = (spell_index + 2) % 3;

        mainSpellIcon.sprite = spell_sprites[spell_index];
        miniSpellIcon1.sprite = spell_sprites[left_spell];
        miniSpellIcon2.sprite = spell_sprites[right_spell];

        hotKeyText1.text = $"{left_spell + 1}";
        hotKeyText2.text = $"{right_spell + 1}";
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

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OnWin()
    {
        resetButton.SetActive(true);
        winText.SetActive(true);
        Cursor.visible = true;
    }

    public void OnLose()
    {
        resetButton.SetActive(true);
        failText.SetActive(true);
        Cursor.visible = true;
    }
}
