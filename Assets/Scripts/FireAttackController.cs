using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackController : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform firePoint;

    [SerializeField, Tooltip("Average attack time")]
    float attackRate;

    [SerializeField, Tooltip("Average attack times")]
    float attackRange;

    [SerializeField]
    float lifeTime;

    float _attackTime;

    bool _canAttack;

    private void Update()
    {
        _attackTime -= Time.deltaTime;
        if (_attackTime < 0.0F)
        {
            _attackTime = 0.0F;
        }

        if (_attackTime > 0.0F)
        {
            return;
        }

        if (!_canAttack)
        {
            return;
        }

        GameObject bullet =
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Destroy(bullet, lifeTime);

        _attackTime = attackRate / attackRange;
    }

    public void SetCanAttack(bool canAttack)
    {
        _canAttack = canAttack;
    }
}
