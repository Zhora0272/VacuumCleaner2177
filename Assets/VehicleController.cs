using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _forcePower;

    private bool _keyW;
    private bool _keyS;
    private bool _keyA;
    private bool _keyD;

    private void Update()
    {
        _keyW = Input.GetKey(KeyCode.W);
        _keyS = Input.GetKey(KeyCode.S);
        _keyA = Input.GetKey(KeyCode.A);
        _keyD = Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        if (_keyW)
        {
            _rb.AddRelativeForce(Vector3.forward * _forcePower, ForceMode.Acceleration);
        }
        if (_keyS)
        {
            _rb.velocity = Vector3.Lerp(_rb.velocity, Vector3.zero, Time.fixedDeltaTime * 25);
        }

        if (_keyA)
        {
            _rb.AddRelativeForce(Vector3.left * _forcePower, ForceMode.Acceleration);
            _rb.AddTorque(-Vector3.up * 2, ForceMode.Acceleration);
        }
        if (_keyD)
        {
            _rb.AddRelativeForce(Vector3.right * _forcePower, ForceMode.Acceleration);
            _rb.AddTorque(Vector3.up * 2, ForceMode.Acceleration);
        }
    }
}