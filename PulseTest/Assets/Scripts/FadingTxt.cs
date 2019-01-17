using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingTxt : MonoBehaviour
{
    public Text textToFade;
    private bool faded = false;
    private float tweenDuration = 0.8f;
    private float tweenUpperbound = 0.8f;
    private float tweenLowerbound = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(textToFade.canvasRenderer.GetAlpha());

    }

    // Update is called once per frame
    private void TweenTxt()
    {
        if (!faded)
        {
            textToFade.CrossFadeAlpha(0, tweenDuration, false);
            if (textToFade.canvasRenderer.GetAlpha() < tweenLowerbound)
            {
                faded = true;
            }
        }
        else
        {
            textToFade.CrossFadeAlpha(1, tweenDuration, false);
            if (textToFade.canvasRenderer.GetAlpha() > tweenUpperbound)
            {
                faded = false;
            }
        }
    }
    void Update()
    {
        TweenTxt();
    }
}
