using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[RequireComponent(typeof(BoxCollider))]
public class Teleport2 : MonoBehaviour
{
    public GameObject interact;
    public GameObject spawnPoint;
    public FadeScript fade;
    private PlayerController controller;
    private bool canTeleport = false;


    private void Awake()
    {
        interact.SetActive(false);

        GameEvents.OnMidTransition.AddListener(Teleportation2);
    }
    [Button]
    public void Init()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void Start()
    {
        controller = PlayerController.Instance;

        controller.OnInteract += ChangeLocation2;
    }

    private void OnDisable()
    {
        controller.OnInteract -= ChangeLocation2;
    }

    public void ChangeLocation2()
    {

        if (canTeleport)
        {
            //fade.FadeIn();
            controller.gameObject.transform.position = spawnPoint.transform.position;
        }
    }

    public void Teleportation2()
    {
        if (canTeleport)
        {
            Debug.Log("Teleport 2");
            //controller.gameObject.transform.position = spawnPoint.transform.position;
            fade.FadeOut();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(true);
            canTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(false);
            canTeleport = false;
        }
    }


}
