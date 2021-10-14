using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    public List<ObjectInTheWay> currentlyInTheWay = new List<ObjectInTheWay>();
    public List<ObjectInTheWay> alreadyTransparent = new List<ObjectInTheWay>();

    private Transform cam;
    private Transform player;
    private void Start()
    {
        cam = this.gameObject.transform;
        player = PlayerController.Instance.transform;
        
    }

    private void Update()
    {
        GetAllObjectInTheWay();
        MakeObjectSolid();
        MakeObjectTransparent();
    }
    private void GetAllObjectInTheWay()
    {
        currentlyInTheWay.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(cam.position - player.position);

        Ray ray1_Forward = new Ray(cam.position, player.position - cam.position);
        Ray ray1_Backward = new Ray(player.position, cam.position - player.position);

        var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

        
        foreach(var hit in hits1_Forward)
        {
            if(hit.collider.gameObject.TryGetComponent(out ObjectInTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }

        foreach (var hit in hits1_Backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out ObjectInTheWay inTheWay))
            {
                if (!currentlyInTheWay.Contains(inTheWay))
                {
                    currentlyInTheWay.Add(inTheWay);
                }
            }
        }
    }

    private void MakeObjectTransparent()
    {
        for(int i = 0; i < currentlyInTheWay.Count; i++)
        {
            ObjectInTheWay inTheWay = currentlyInTheWay[i];

            if (!alreadyTransparent.Contains(inTheWay))
            {
                inTheWay.ShowTransparent();
                alreadyTransparent.Add(inTheWay);
            }
        }
    }

    private void MakeObjectSolid()
    {
        for (int i = alreadyTransparent.Count - 1; i >= 0; i--)
        {
            ObjectInTheWay wasInTheWay = alreadyTransparent[i];

            if (!currentlyInTheWay.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                alreadyTransparent.Remove(wasInTheWay);
            }
        }
    }
}
