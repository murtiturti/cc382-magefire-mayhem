using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "FireballAttack", menuName = "Attacks/Fire")]
public class Fireball : Attack
{
    private float _cooldownTimer = 0f;
    public override IEnumerator Cast(Transform casterTransform)
    {
        return ScaleFireball(casterTransform);
    }

    public IEnumerator ScaleFireball(Transform casterTransform)
    {
        var fireball = Instantiate(prefab, casterTransform.transform.position + 
                                     casterTransform.forward + casterTransform.up, 
            Quaternion.identity);
        fireball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        var timer = 0f;
        while (timer <= castTime)
        {
            timer += Time.deltaTime;
            fireball.transform.localScale = Vector3.Lerp(fireball.transform.localScale, new Vector3(1.0f, 1f, 1f), timer / castTime);
            yield return null;
        }
        fireball.GetComponent<ShootForward>().Shoot();
    }
}
