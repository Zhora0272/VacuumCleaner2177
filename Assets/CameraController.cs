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
        transform.LookAt((_target.position + _target.forward) + _lookOffset);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position - _target.forward * 3, Time.fixedDeltaTime * _smooth) + _offset;
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
