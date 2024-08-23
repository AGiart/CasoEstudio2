using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndRetreatAI : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float speed;

    [SerializeField]
    float stopDistance;

    [SerializeField]
    float retreatDistance;

    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(_rigidbody.position, target.position);

        if (distance > stopDistance)
        {
            _rigidbody.position = 
                Vector3.MoveTowards(_rigidbody.position, target.position, speed * Time.fixedDeltaTime);
        }
        else if (distance < retreatDistance)
        {
            _rigidbody.position =
                Vector3.MoveTowards(_rigidbody.position, target.position, -speed * Time.fixedDeltaTime);
        }
        else if (distance < stopDistance && distance > retreatDistance)
        {
            _rigidbody.position = this._rigidbody.position;
        }

        transform.LookAt(target.position);
    }
}
