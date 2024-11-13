using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    private float _timer = 0f;
    private bool _isReady = true;
    
    public void StartCooldown(float cooldownTime)
    {
        StartCoroutine(CooldownRoutine(cooldownTime));
    }

    private IEnumerator CooldownRoutine(float cooldownTime)
    {
        _isReady = false;
        yield return new WaitForSeconds(cooldownTime);
        _isReady = true;
    }

    public bool IsReady()
    {
        return _isReady;
    }
}
