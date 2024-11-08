using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
    [SerializeField] protected float castTime;
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected float damage;
    [SerializeField] protected EAttackType attackType;
    [SerializeField] protected GameObject prefab;
    public abstract IEnumerator Cast(Transform casterTransform);
}
