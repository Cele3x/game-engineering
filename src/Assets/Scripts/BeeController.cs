using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeController : MonoBehaviour
{
    public Transform target;

    private GameController _gameController;
    private NavMeshAgent _navMeshAgent;
    private Animator _beeAnimator;
    private float _distanceToTarget = Mathf.Infinity;
    private Boolean _isSuccessful;

    private static readonly int Attack = Animator.StringToHash("attack");
    private static readonly int Move = Animator.StringToHash("move");
    private static readonly int Idle = Animator.StringToHash("idle");
    private static readonly int Die = Animator.StringToHash("die");

    void Start()
    {
        //target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        _beeAnimator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _beeAnimator.SetBool(Idle, true);
    }
    
    void Update()
    {
        if (_isSuccessful)
        {
            GetAway();
            return;
        }
        _distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        _beeAnimator.SetBool(Idle, false);
        _beeAnimator.SetBool(Move, true);
        _navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        _beeAnimator.SetBool(Move, false);
        _beeAnimator.SetTrigger(Attack);
        _beeAnimator.SetBool(Idle, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isSuccessful) return;
        _isSuccessful = true;
        _gameController.BeeScores();
        _navMeshAgent.enabled = false;
    }

    private void GetAway()
    {
        transform.position += Vector3.up * Time.deltaTime;
        Destroy(gameObject, 8.0f);
    }
}
