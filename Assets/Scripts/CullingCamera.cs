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
            if (hit.collider.gameObject.CompareTag("Culling"))
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
        }
    }
}
