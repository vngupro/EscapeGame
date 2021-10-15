using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneScript : MonoBehaviour
{
    public float timeDash = 1.5f;
    public float timeDot = 0.5f;
    public float timePause = 0.5f;
    public float timeBetweenLetter = 1.5f;
    public CanvasGroup canvas;

    public MorseState state;
    public AudioSource audioS;
    private bool hasFinishSignal = true;

    public GameObject triggerArmoire;
    private void Awake()
    {
        state = MorseState.ONE;
        hasFinishSignal = true;
    }

    private void OnEnable()
    {
        triggerArmoire.SetActive(true);
        audioS.loop = false;
        audioS.volume = 0;
        audioS.Stop();
    }
    private void Update()
    {
        switch (state)
        {
            case MorseState.ONE:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.TWO:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.THREE:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayPause());
                }
                break;
            case MorseState.FOUR:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.FIVE:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.SIX:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.SEVEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayPause());
                }
                break;
            case MorseState.EIGHT:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.NINE:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.TEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayPause());
                }
                break;
            case MorseState.ELEVEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.TWELVE:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.THIRTEEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.FOURTEEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayPause());
                }
                break;
            case MorseState.FIFTEEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.SIXTEEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.SEVENTEEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayPause());
                }
                break;
            case MorseState.EIGHTEEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.NINETEEN:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDash());
                }
                break;
            case MorseState.TWENTY:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.TWENTYONE:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayPause());
                }
                break;
            case MorseState.TWENTYTWO:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayDot());
                }
                break;
            case MorseState.TWENTYTHREE:
                if (hasFinishSignal)
                {
                    StartCoroutine(PlayPause());
                }
                break;
        }
    }
    private IEnumerator PlayDot()
    {
        hasFinishSignal = false; 
        float timer = 0.0f;
        canvas.alpha = 1;
        while (timer < timeDot)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        //Pause dot
        timer = 0.0f;
        canvas.alpha = 0;
        while (timer < timePause)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        hasFinishSignal = true;
        state++;
    }

    private IEnumerator PlayDash()
    {
        hasFinishSignal = false;
        float timer = 0;
        canvas.alpha = 1;
        while (timer < timeDash)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        //Pause dot
        timer = 0.0f;
        canvas.alpha = 0;
        while (timer < timePause)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        hasFinishSignal = true;
        state++;
    }

    private IEnumerator PlayPause()
    {
        hasFinishSignal = false;
        float timer = 0.0f;
        canvas.alpha = 0;
        while (timer < timeBetweenLetter)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        hasFinishSignal = true;
        state++;

        if (state == MorseState.TWENTYFOUR)
        {
            state = MorseState.ONE;
        }
    }
}

public enum MorseState
{
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    TEN,
    ELEVEN,
    TWELVE,
    THIRTEEN,
    FOURTEEN,
    FIFTEEN,
    SIXTEEN,
    SEVENTEEN,
    EIGHTEEN,
    NINETEEN,
    TWENTY,
    TWENTYONE,
    TWENTYTWO,
    TWENTYTHREE,
    TWENTYFOUR
}
