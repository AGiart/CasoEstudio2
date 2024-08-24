using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField]
    Transform[] attackPoints;


    [SerializeField]
    float japDamage;

    private enum AttackModes
    {
        JAP = 1,
        UPPERCUT = 2,
        LOWPICK = 3,
        HIGH_KICK = 4,
        KO = 5
    }

    private StarterAssetsInputs _inputs;
    private Animator _animator;

    private int ANIMATION_ATTACK;
    private int ANIMATION_MODE;

    private AttackModes _attackMode;

    private int _japSequence;

    private void Awake()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        ANIMATION_ATTACK = Animator.StringToHash("Attack");
        ANIMATION_MODE = Animator.StringToHash("Mode");
    }
    private void Update()
    {
        if (_inputs.jap)
        {
            _japSequence = 0;

            _inputs.jap = false;
            _attackMode = AttackModes.JAP;

            _animator.SetInteger(ANIMATION_MODE, (int)_attackMode);
            _animator.SetTrigger(ANIMATION_ATTACK);

            StartCoroutine(CancelTriggerCoroutine());
        }
    }

    private IEnumerator CancelTriggerCoroutine()
    {
        yield return new WaitForSeconds(0.5F);

        _animator.SetInteger(ANIMATION_MODE, 0);
        _animator.ResetTrigger(ANIMATION_ATTACK);
    }

   private Transform GetAttackpoint(string name)
    {

        foreach (Transform attackPoint in attackPoints)
        {

            if (attackPoint.name == name)
            {
                return attackPoint;
            }
        }
        return null;
    }

    public void attackTrigger()
    {
        _japSequence++;

        Transform attackPoint = GetAttackpoint("Jap " + _japSequence.ToString());
        if (attackPoint != null)
        {
            
            Collider[] colliders = Physics.OverlapSphere(attackPoint.position, 0.15F);
            foreach(Collider collider in colliders)
            {
                DamageableController damageable = collider.GetComponent<DamageableController>();
                if (damageable == null)
                {
                    continue;
                }

                damageable.TakeDamage(japDamage);
            }
        }
    }

}
