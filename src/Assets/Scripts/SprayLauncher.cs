using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayLauncher : MonoBehaviour

{
    public ParticleSystem particleLauncher;
    public GameObject nozle;
    public GameObject hole;
    private Vector3 nozlePosSteady = new Vector3(0, 0, 0);
    private Vector3 nozlePosPressed = new Vector3(0, (float)-0.1, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        { /*particleLauncher.Play();*/
            particleLauncher.Emit(5);

            nozle.transform.localPosition = nozlePosPressed;
            hole.transform.localPosition = nozlePosPressed;

        }

        if (Input.GetButtonUp("Fire1"))
        {
            nozle.transform.localPosition = nozlePosSteady;
            hole.transform.localPosition = nozlePosSteady;
        }
    }
}
