using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float attackDistance;

    FireAttackController _fireController;
    NavMeshAgent _navAgent;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _fireController = GetComponent<FireAttackController>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        bool canAttack = distance <= attackDistance;
        _fireController.SetCanAttack(canAttack);
        _navAgent.SetDestination(target.position);
    }
}
