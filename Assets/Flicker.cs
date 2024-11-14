using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private Light _torchLight;

    [SerializeField] private float maxIntensity;
    [SerializeField] private float minIntensity;

    [SerializeField] private float minTimeToSurge;
    [SerializeField] private float maxTimeToSurge;

    private float _surgeTimer = 0f;
    private float _timeToSurge;
    private bool _surgeTimePicked;
    private float _surgeValue;
    
    // Start is called before the first frame update
    void Start()
    {
        _torchLight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_surgeTimePicked)
        {
            TimeToSurge();
            SurgeValue();
        }
        _surgeTimer += Time.deltaTime;
        _torchLight.intensity = Mathf.Lerp(_torchLight.intensity, _surgeValue, _surgeTimer / _timeToSurge * Time.deltaTime );
        if (_surgeTimer >= _timeToSurge)
        {
            _surgeTimePicked = false;
        }
    }

    private void TimeToSurge()
    {
        _timeToSurge = Random.Range(minTimeToSurge, maxTimeToSurge);
        _surgeTimePicked = true;
    }

    private void SurgeValue()
    {
        _surgeValue = Random.Range(minIntensity, maxIntensity);
    }
}
