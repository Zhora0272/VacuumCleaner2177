using System;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _lookOffset;
    [SerializeField] private float _smooth;

    private Vector3 _lastPosition;

    private void Start()
    {
        StartCoroutine(TargetPathTracking());
    }

    private void Update()
    {
        transform.LookAt(_target.position + _target.forward);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, (-_target.forward * 2) + _offset, Time.fixedDeltaTime * _smooth);
    }

    IEnumerator TargetPathTracking()
    {
        var waitYield = new WaitForSeconds(1);

        while (true)
        {
            yield return waitYield;
            _lastPosition = transform.position;
        }
    }
}
