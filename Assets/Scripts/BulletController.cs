using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    LayerMask targetMask;

    [SerializeField]
    float speed;

    [SerializeField]
    float damage;

    [SerializeField]
    bool damagePercentage;

    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((targetMask.value & (1 << other.gameObject.layer)) != 0)
        {
            HealthController controller = other.gameObject.GetComponent<HealthController>();
            controller.DecreaseHealth(damage, damagePercentage);
        }

        Destroy(gameObject);
    }
}
