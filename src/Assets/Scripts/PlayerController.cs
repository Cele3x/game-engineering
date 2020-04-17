using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour
{
    //Health
    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth = 10;

    public GameObject swatter;
    private Animator animator;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
    private static readonly int Spray1 = Animator.StringToHash("spray");
    private static readonly int Hit1 = Animator.StringToHash("hit");

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Hit();
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Spray();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        CalcHealth();
    }

    private void CalcHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        onHealthChangedCallback?.Invoke();
    }

    void Hit()
    {
        // play attack animation
        animator.SetTrigger(Hit1);
        // detect enemies in range of attack
        // damage them
    }

    void Spray()
    {
        animator.SetTrigger(Spray1);
    }
}
