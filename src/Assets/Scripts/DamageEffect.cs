using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    /*
     * Red Flash effect to signalize, that the player gets hurt
     * Fade out as in:
     * https://gamedev.stackexchange.com/questions/111531/fade-in-and-fade-out-gui-texture?rq=1
     */

    public Texture damageFeedback;
    private float alpha = 1.0f;
    private float fadeDir = -1;
    float fadeSpeed = 0.2f;
    int drawDepth = -1000;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha == 0)
        {
            this.enabled = false;
        }
    }

    public void Flash()
    {
        alpha = 1.0f;
    }


    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), damageFeedback, ScaleMode.StretchToFill);
        GUI.depth = drawDepth; ;
    }

}
