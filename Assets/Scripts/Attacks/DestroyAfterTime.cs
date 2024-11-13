using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField][Range(5f, 15f)] private float timeToDestroy = 15f;

    private float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
