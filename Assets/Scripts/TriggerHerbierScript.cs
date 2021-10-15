using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHerbierScript : MonoBehaviour
{

    public GameObject triggerHerbier;
    private void OnEnable()
    {
        triggerHerbier.SetActive(true);
    }
}
