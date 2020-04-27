using System;
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
    public GameObject spray;
    public SprayBar sprayBar;

    private SprayLauncher sprayLauncher;
    private Animator animator;
    private KeyCode swatterKey;
    private KeyCode sprayKey;

    private float sprayTimer = 0;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    private bool canSpray = false;

    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    private static readonly int Spray1 = Animator.StringToHash("spray");
    private static readonly string HitStateName = "Hit";
    private static readonly int Hit1 = Animator.StringToHash("hit");


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprayLauncher = spray.GetComponentInChildren<SprayLauncher>();
        spray.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetControlScheme();

        if (Input.GetKeyDown(swatterKey))
        {
            Hit();
        } 
        if (Input.GetKey(sprayKey))
        {
            Spray();
        }
        else if (Input.GetKeyUp(sprayKey))
        {
            StopSpray();
        }
    }


    public void OnSwatterGridTrigger(Collider other) {
        
        if (other.CompareTag("Enemy"))
        {
            //Checks if attack animation is playing
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

            if (info.IsName("Hit"))
            {
                Debug.Log("I punched a bee");
                BeeController beeCtrl = other.GetComponent<BeeController>();
                beeCtrl.OnSwatterHit(swatter);


            }
        }


    }

    internal void CollectSpray()
    {
        spray.SetActive(true);
        sprayBar.SetSprayBarVisibility(true);
        canSpray = true;
        sprayTimer = 0;
        sprayBar.ResetSprayBar();
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
        //animator.SetTrigger(Spray1);
        if (canSpray) 
        { 
            sprayLauncher.EmitSpray();
            sprayTimer += Time.deltaTime;
            sprayBar.SetCurrentSprayBarValue();
        }

        if (sprayTimer >= 4)
        {
            canSpray = false;
            sprayLauncher.StopSpray();
            spray.SetActive(false);
            sprayBar.SetSprayBarVisibility(false);
        }

    }

    private void StopSpray()
    {
        if (canSpray)
        {
            sprayLauncher.StopSpray();
        }
    }

    private void SetControlScheme()
    {
        if (PlayerPrefs.GetString("ControlSetting", "defaultControls") == "defaultControls")
        {
            swatterKey = KeyCode.Mouse0;
            sprayKey = KeyCode.Mouse1;
        }
        else if (PlayerPrefs.GetString("ControlSetting", "defaultControls") == "altControls")
        {
            swatterKey = KeyCode.Mouse1;
            sprayKey = KeyCode.Mouse0;
        }
    }
}
