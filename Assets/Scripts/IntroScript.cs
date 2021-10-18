using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public CanvasGroup canvas;
    public float timeIntro = 2.0f;
    public float timeFade = 2.0f;

    private void Start()
    {
        StartCoroutine(DoIntroFade());
    }

    private IEnumerator DoIntroFade()
    {
        yield return new WaitForSeconds(timeIntro);
        float timer = 0.0f;
        while(timer < timeFade)
        {
            timer += Time.deltaTime;
            float ratio = timer / timeFade;
            canvas.alpha = Mathf.Lerp(1, 0, ratio);
            yield return null;
        }

        this.gameObject.SetActive(false);
        
    }
}
