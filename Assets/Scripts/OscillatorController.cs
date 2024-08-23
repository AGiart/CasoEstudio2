using UnityEngine;

public class OscillatorController : MonoBehaviour
{
    [SerializeField]
    Vector3 distance;

    Rigidbody _rigidbody;

    Vector3 _startPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startPosition = _rigidbody.position;
    }

    private void FixedUpdate()
    {
        if (distance.x != 0.0F)
        {
            Vector3 currentPosition = _rigidbody.position;
            currentPosition.x = _startPosition.x + Mathf.PingPong(Time.time, distance.x);
            _rigidbody.position = currentPosition;
        }

        if (distance.y != 0.0F)
        {
            Vector3 currentPosition = _rigidbody.position;
            currentPosition.y = _startPosition.y + Mathf.PingPong(Time.time, distance.y);
            _rigidbody.position = currentPosition;
        }

        if (distance.z != 0.0F)
        {
            Vector3 currentPosition = _rigidbody.position;
            currentPosition.z = _startPosition.z + Mathf.PingPong(Time.time, distance.z);
            _rigidbody.position = currentPosition;
        }
    }
}
