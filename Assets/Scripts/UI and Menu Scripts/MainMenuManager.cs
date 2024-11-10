using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HoverButton(Transform buttonTrans)
    {
        buttonTrans.localScale = new Vector3(1.15f, 1.15f, 1f);
    }

    public void HoverOffButton(Transform buttonTrans)
    {
        buttonTrans.localScale = new Vector3(1f, 1f, 1f);
    }
}
