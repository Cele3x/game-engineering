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
    private Rigidbody rigidBody;
    private AudioSource _audioSource;
    private float _distanceToTarget = Mathf.Infinity;
    private Boolean _isSuccessful;
    private Boolean isNumb;
    private Boolean isDead=false;

    private int health=2;

    private float numbTimeLeft;
    private float levelTime;
    private float numbDuration = 10.0f;
    private float initialWingSpeed;
    private float initialNavSpeed;
    private float initialAudioPitch;
    private float numbWingSpeed = 0.2f;
    private float numbNavSpeed = 0.35f;
    private float numbAudioPitch = 0.35f;

    private static readonly int Attack = Animator.StringToHash("attack");
    private static readonly int Move = Animator.StringToHash("move");
    private static readonly int Idle = Animator.StringToHash("idle");
    private static readonly int Die = Animator.StringToHash("die");
    private static readonly int Damage = Animator.StringToHash("takedamage");

    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        _beeAnimator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        _beeAnimator.SetBool(Idle, true);
        initialWingSpeed = _beeAnimator.speed;
        initialNavSpeed = _navMeshAgent.speed;
        initialAudioPitch = _audioSource.pitch;
    }
    
    void Update()
    {

        if (isNumb)
        {
            UpdateNumbTimer();
        }
        if (_isSuccessful)
        {
            GetAway();
        }
        else
        {
            _distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
            {
                ChaseTarget();
            } 
            else if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
            {
                AttackTarget();
            }


        }
    }

    private void UpdateNumbTimer() {

        numbTimeLeft = levelTime - Time.timeSinceLevelLoad;
   
        if (Math.Round(numbTimeLeft, 2) == 0 || Math.Round(numbTimeLeft, 2) < 0)
        {
            SetNumbState(false);
        }
       // Debug.Log("Time Left: "+ Math.Round(numbTimeLeft, 2));

    }

    private void ChaseTarget()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        _beeAnimator.SetBool(Idle, false);
        _beeAnimator.SetBool(Move, true);
        _navMeshAgent.SetDestination(target.position);
    }

    private void  AttackTarget()
    {
        _beeAnimator.SetBool(Move, false);
        _beeAnimator.SetTrigger(Attack);
        _beeAnimator.SetBool(Move, true);
    }


    private void OnParticleCollision(GameObject other)
    {
  
        if (!isNumb) {
            SetNumbState(true);
        }
       
    }

    private void SetNumbState(bool becomeNumb)
    {
        if (becomeNumb)
        {
            levelTime = Time.timeSinceLevelLoad + numbDuration;
            isNumb = true;
            _beeAnimator.speed = numbWingSpeed;
            _navMeshAgent.speed = numbNavSpeed;
            _audioSource.pitch = numbAudioPitch;
        }
        else
        {
            _beeAnimator.speed = initialWingSpeed;
            _navMeshAgent.speed =initialNavSpeed;
            _audioSource.pitch = initialAudioPitch;
            isNumb = false;

        }

    }
    public void CollisionFromChild(Collider other)
    {
        if (_isSuccessful) return;
        _isSuccessful = true;
        _gameController.BeeScores();
        _navMeshAgent.enabled = false;
    }
    public void OnSwatterHit(GameObject swatter) {

        int force = 1000;
        _beeAnimator.SetTrigger(Damage);
        transform.LookAt(swatter.transform.position);
   
        var dir = -(swatter.transform.position - transform.position).normalized;
        rigidBody.AddForce(dir * force, ForceMode.Impulse);
        //rigidBody.AddForce(transform.forward * -1000, ForceMode.Impulse);
        //transform.position = Vector3.Lerp(transform.position, transform.forward * -200, Time.deltaTime*0.1f);

        if (!_isSuccessful&&!isDead)
        {
            StartCoroutine(PlayAudioFeedbackDmg());
            DealDamage();
            
        }
    }

    /* Gets called in OnSwatterHit if Bee not already dying or successful
     * Decreases the bee's health points.
     * If no health points are left, navMeshAgent, animator, audiosource
     * and the gameController get informed, numb state gets lifted
     * rigidbody constraits get lifted in order to fall on the floor
     * components are destroyed
    */
    private void DealDamage()
    {
        health--;

        if (health <= 0) {
            _gameController.PlayerScores();
            _beeAnimator.SetBool(Idle, false);
            _beeAnimator.SetBool(Die, true);
            _navMeshAgent.enabled = false;
            rigidBody.useGravity = true;
            rigidBody.drag = 0;
            SetNumbState(false);
            isDead = true;
            Destroy(_audioSource);
            Destroy(_navMeshAgent);
            Destroy(this);
        }
    }

    private void GetAway()
    {
        _audioSource.Stop();
        transform.position += Vector3.up * Time.deltaTime;
        Destroy(gameObject, 8.0f);
    }


    IEnumerator PlayAudioFeedbackDmg()
    {
        _audioSource.pitch += 0.9f;
        _audioSource.volume += 0.4f;
        yield return new WaitForSeconds(0.3f);
        
        _audioSource.pitch -= 0.9f;
        _audioSource.volume -= 0.4f;

    }

}
