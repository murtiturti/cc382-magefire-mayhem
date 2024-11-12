using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "FireballAttack", menuName = "Attacks/Fire")]
public class Fireball : Attack
{
    public override IEnumerator Cast(Transform casterTransform)
    {
        return ScaleFireball(casterTransform);
    }

    private IEnumerator ScaleFireball(Transform casterTransform)
    {
        var fireball = Instantiate(prefab, casterTransform.transform.position + casterTransform.forward + casterTransform.up, Quaternion.identity);
        fireball.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
        var timer = 0f;
        while (timer <= castTime)
        {
            timer += Time.deltaTime;
            fireball.transform.localScale = Vector3.Lerp(fireball.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), timer / castTime);
            yield return null;
        }
        fireball.GetComponent<ShootForward>().Shoot();
    }
}
