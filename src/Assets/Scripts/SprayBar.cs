using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SprayBar : MonoBehaviour
{

    public Slider sprayBarFill;
    public GameObject sprayBar;

    private float maxSprayDuration = 4;


    void Awake()
    {
        sprayBarFill = GetComponent<Slider>();
    }

    public void ResetSprayBar()
    {
        sprayBarFill.value = maxSprayDuration;
    }

    public void SetCurrentSprayBarValue()
    {
        sprayBarFill.value -= Time.deltaTime;
    }

    public void SetSprayBarVisibility(bool isSprayBarActive)
    {
        sprayBar.SetActive(isSprayBarActive);
    }
}
