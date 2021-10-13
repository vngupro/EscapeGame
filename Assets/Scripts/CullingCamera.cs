using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingCamera : MonoBehaviour
{
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        foreach(RaycastHit hit in hits)
        {
            Renderer rend = hit.transform.GetComponent<Renderer>();
            if (rend)
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    return;

                }
                else
                {
                    rend.material.shader = Shader.Find("Universal Render Pipeline/Unlit");
                    Color tempColor = rend.material.color;
                    tempColor.a = 0.3F;
                    rend.material.color = tempColor;
                }
            }
        }
    }
}
