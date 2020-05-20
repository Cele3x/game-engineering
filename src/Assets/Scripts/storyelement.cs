using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyelement : MonoBehaviour {


    public Dialog dialog; 

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }

}
