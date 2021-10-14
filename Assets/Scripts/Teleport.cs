using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DoorDetection))]
public class Teleport : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject newTrigger;
    public FadeScript fade;
    private DoorDetection door;

    private void Awake()
    {
        door = GetComponent<DoorDetection>();

        GameEvents.OnMidTransition.AddListener(Teleportation);
    }
    private void OnEnable()
    {
        if(door == null) { return; }
        door.OnTeleport += ChangeLocation;
    }

    private void OnDisable()
    {
        if (door == null) { return; }
        door.OnTeleport -= ChangeLocation;
    }

    public void ChangeLocation()
    {
        fade.Transition();

    }

    public void Teleportation()
    {
        PlayerController.Instance.gameObject.transform.position = spawnPoint.transform.position;
        newTrigger.SetActive(true);
    }
}
