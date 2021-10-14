using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class FadeScript : MonoBehaviour
{
    public CanvasGroup canvas;
    public float fadeTime = 2.0f;
    public AnimationCurve curve;

    private void Awake()
    {
        canvas.alpha = 0;
    }
    [Button]
    public void FadeIn()
    {
        StartCoroutine(Fade(0, 1));
    }
    [Button]
    public void FadeOut()
    {
        StartCoroutine(Fade(1, 0));
    }

    public void Transition()
    {
        StartCoroutine(DoTransition(0, 1));
    }
    private IEnumerator Fade(int min, int max)
    {
        float timer = 0;

        while(timer <= fadeTime)
        {
            float ratio = timer / fadeTime;
            timer += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(min, max, curve.Evaluate(ratio));
            yield return null;
        }

        canvas.alpha = max;

        if(max == 1)
        {
            GameEvents.OnMidTransition.Invoke();
        }
    }

    private IEnumerator DoTransition(int min, int max)
    {
        float timer = 0;

        while (timer <= fadeTime)
        {
            float ratio = timer / fadeTime;
            timer += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(min, max, curve.Evaluate(ratio));
            yield return null;
        }

        canvas.alpha = max;
        GameEvents.OnMidTransition.Invoke();
        timer = 0;

        while (timer <= fadeTime)
        {
            float ratio = timer / fadeTime;
            timer += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(max, min, curve.Evaluate(ratio));
            yield return null;
        }

        canvas.alpha = min;

        
    }
}
