using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Event
    
    #endregion
    public float speed = 10.0f;
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        // Read the movement value
        float moveHorizontal = playerControls.Map.MoveHorizontal.ReadValue<float>();
        float moveVertical = playerControls.Map.MoveVertical.ReadValue<float>();

        Vector3 currentPos = transform.position;
        currentPos.x += moveHorizontal * speed * Time.deltaTime;
        currentPos.z += moveVertical * speed * Time.deltaTime;
        transform.position = currentPos;
        //playerControls.Map.Interact.ReadValue<float>();
        // Move the Player
        // Read the interaction value
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide 3D");
    }
}
