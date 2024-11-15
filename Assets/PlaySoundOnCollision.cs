using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private void OnCollisionEnter(Collision other)
    {
        Sound_Effects.Instance.Play_Sound_Effects(clip, transform, 1);
    }
}
