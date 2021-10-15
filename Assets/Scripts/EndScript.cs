using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject canvasInteract;
    public GameObject canvasItem;
    public FadeScript fade;
    public float fadeTime = 2.0f;
    public float fadeDuration = 1.0f;
    public AnimationCurve curve;
    private PlayerController controller;
    public GameObject triggerEnd;
    private bool canEnd = false;
    private bool canOpen = false;

    public AudioSource s;
    private void Start()
    {
        controller = PlayerController.Instance;
        controller.OnInteract += OpenItem;
        controller.OnInteract += End;
    }
    private void OnEnable()
    {
        canvasInteract.SetActive(false);
        canEnd = false;
        canOpen = false;
    }
    private void OnDisable()
    {
        controller.OnInteract -= OpenItem;
        controller.OnInteract -= End;
    }

    public void End()
    {
        if (canEnd)
        {
            StartCoroutine(DoEnding(0, 1));
        }
    }

    public void OpenItem()
    {
        if (canOpen)
        {
            canvasItem.SetActive(true);
            canEnd = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasInteract.SetActive(true);
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasInteract.SetActive(false);
            canOpen = false;
        }
    }
    private IEnumerator DoEnding(int min, int max)
    {
        SoundManager.Instance.StopAllSound();
        s.volume = 0;
        s.Stop();
        float timer = 0;
        while (timer <= fadeTime)
        {
            float ratio = timer / fadeTime;
            timer += Time.deltaTime;
            fade.canvas.alpha = Mathf.Lerp(min, max, curve.Evaluate(ratio));
            yield return null;
        }
        fade.canvas.alpha = max;

        triggerEnd.SetActive(true);
        yield return new WaitForSeconds(fadeDuration);

        timer = 0;
        while (timer <= fadeTime)
        {
            float ratio = timer / fadeTime;
            timer += Time.deltaTime;
            fade.canvas.alpha = Mathf.Lerp(max, min, curve.Evaluate(ratio));
            yield return null;
        }
        fade.canvas.alpha = min;
        SoundManager.Instance.PlaySound("End");
    }
}
