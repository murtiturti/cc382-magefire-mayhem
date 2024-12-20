using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
    [SerializeField] protected float castTime;
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected int damage;
    [SerializeField] public EAttackType attackType;
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected int manaConsumption;
    [SerializeField] protected bool useGravity;
    [SerializeField] protected AudioClip soundFX;
    public abstract IEnumerator Cast(Transform casterTransform);

    public float CooldownTime()
    {
        return cooldownTime;
    }

    public int DamageVal()
    {
        return damage;
    }

    public int Mana()
    {
        return manaConsumption;
    }

    public AudioClip SoundFX()
    {
        return soundFX;
    }
    
}
