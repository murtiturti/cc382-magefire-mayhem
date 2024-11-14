using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Fireball", menuName = "Attacks/Enemy")]
public class EnemyAttack : Attack
{
    public float fireballSpeed;
    public override IEnumerator Cast(Transform casterTransform)
    {
        return EnemyFireball(casterTransform);
    }

    private IEnumerator EnemyFireball(Transform casterTransform)
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
        ParticleSystem firePS = fireball.GetComponentInChildren<ParticleSystem>();
        firePS.Play();
        var focus = fireball.GetComponent<ShootForward>();
        focus.Shoot(fireballSpeed);
    }
}
