using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "IceBladesAttack", menuName = "Attacks/Ice")]
public class IceBlades : Attack
{
    private Transform playerTrans;
    public int numBlades = 6;
    public float radius = 1f;
    public float shootSpeed = 10f;

    public override IEnumerator Cast(Transform casterTransform)
    {
        return InitBlades(casterTransform);
    }

    private IEnumerator InitBlades(Transform casterTransform)
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        var center = casterTransform.position + 2f * casterTransform.forward + casterTransform.up;
        var dTheta = 360f / numBlades;
        var blades = new List<GameObject>();
        for (int i = 0; i < numBlades; i++)
        {
            var position = new Vector3(center.x + radius * Mathf.Cos(Mathf.Deg2Rad * (dTheta * i)),
                                       center.y + radius * Mathf.Sin(Mathf.Deg2Rad * (dTheta * i)),
                                       center.z);
            var new_blade = Instantiate(prefab, position, playerTrans.rotation);
            blades.Add(new_blade);
            
            yield return new WaitForSeconds(castTime / numBlades);
        }
        var mousePos = Input.mousePosition;
        mousePos.z = 10f;
        foreach (var blade in blades)
        {
            ParticleSystem icePS = blade.GetComponentInChildren<ParticleSystem>();
            icePS.Play();
            var focus = blade.GetComponent<FocusOnPoint>();
            focus.Focus(Camera.main.ScreenToWorldPoint(mousePos));
            focus.Shoot(shootSpeed, "ice");
            
        }
    }
}
