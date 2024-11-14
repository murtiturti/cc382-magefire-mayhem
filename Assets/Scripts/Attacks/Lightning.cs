using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lightning Bolt", menuName = "Attacks/Lightning")]
public class Lightning : Attack
{
    public float boltSpeed = 10f;
    public override IEnumerator Cast(Transform casterTransform)
    {
        return Stretch(casterTransform);
    }

    private IEnumerator Stretch(Transform casterTransform)
    {
        var position = casterTransform.position + 2 * casterTransform.forward + casterTransform.up + casterTransform.right;
        var bolt = Instantiate(prefab, position, prefab.transform.rotation);
        yield return null;
        var timer = 0f;
        while (timer <= castTime)
        {
            timer += Time.deltaTime;
            bolt.transform.localScale = Vector3.Lerp(bolt.transform.localScale, 
                new Vector3(bolt.transform.localScale.x, bolt.transform.localScale.y, 6f), 
                timer);
            yield return null;
        }
        var mousePos = Input.mousePosition;
        mousePos.z = 10f;
        var focus = bolt.GetComponent<FocusOnPoint>();
        focus.Focus(Camera.main.ScreenToWorldPoint(mousePos));
        focus.Shoot(boltSpeed, useGravity);
        
        
    }
}
