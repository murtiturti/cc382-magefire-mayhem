using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCountHorde : MonoBehaviour
{
    private float winCheckTimer = 0f;

    private void Update()
    {
        winCheckTimer += Time.deltaTime;
        if (winCheckTimer >= 5f)
        {
            winCheckTimer = 0f;
            var goblinCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (goblinCount == 0)
            {
                Time.timeScale = 0f;
                UIManager.ui_manager.OnWin();
            }
        }
    }
}
