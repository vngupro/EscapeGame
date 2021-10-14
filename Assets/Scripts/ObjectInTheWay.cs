using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInTheWay : MonoBehaviour
{
    public GameObject solidBody;
    public GameObject transparentBody;

    private void Awake()
    {
        //ShowSolid();
    }

    public void ShowSolid()
    {
        solidBody.SetActive(true);
        transparentBody.SetActive(false);
    }

    public void ShowTransparent()
    {
        solidBody.SetActive(false);
        transparentBody.SetActive(true);
    }
}
