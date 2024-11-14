using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "IceBladesAttack", menuName = "Attacks/Ice")]
public class IceBlades : Attack
{
    public int numBlades = 6;
    public float radius = 1f;
    public float shootSpeed = 10f;
    
    public override IEnumerator Cast(Transform casterTransform)
    {
        return InitBlades(casterTransform);
    }

    private IEnumerator InitBlades(Transform casterTransform)
    {
        var center = casterTransform.position + 2f * casterTransform.forward + casterTransform.up;
        var dTheta = 360f / numBlades;
        var blades = new List<GameObject>();
        for (int i = 0; i < numBlades; i++)
        {
            var locPosition = center + casterTransform.up * radius;
            var direction = locPosition - center;
            Quaternion rotation = Quaternion.AngleAxis(dTheta * i, casterTransform.forward);
            direction = rotation * direction;
            Vector3 point = direction + center;

            var go = Instantiate(prefab, point, Quaternion.LookRotation(casterTransform.forward, casterTransform.up));
            blades.Add(go);
            
            yield return new WaitForSeconds(castTime / numBlades);
        }
        var mousePos = Input.mousePosition;
        mousePos.z = 10f;
        foreach (var blade in blades)
        {
            var focus = blade.GetComponent<FocusOnPoint>();
            focus.Focus(Camera.main.ScreenToWorldPoint(mousePos));
            focus.Shoot(shootSpeed, useGravity);
        }
    }
}
