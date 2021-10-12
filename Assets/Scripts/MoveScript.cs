using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScript : MonoBehaviour
{
    public float speed = 10.0f;

    private Coroutine doHorizontal;
    private Coroutine doVertical;
    private Rigidbody rb;
    private PlayerController controller;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = PlayerController.Instance;
        
        controller.OnMoveHorizontal += MoveHorizontal;
        controller.OnMoveVertical += MoveVertical;
        controller.OnEndHorizontal += EndMoveHorizontal;
        controller.OnEndVertical += EndMoveVertical;
    }
    public void OnDisable()
    {
        controller.OnMoveHorizontal -= MoveHorizontal;
        controller.OnMoveVertical -= MoveVertical;
        controller.OnEndHorizontal -= EndMoveHorizontal;
        controller.OnEndVertical -= EndMoveVertical;
    }

    public void MoveHorizontal(float direction)
    {
        doHorizontal = StartCoroutine(DoMoveHorizontal(direction));
    }

    public void MoveVertical(float direction)
    {
        doVertical = StartCoroutine(DoMoveVertical(direction));
    }

    public void EndMoveHorizontal(float direction)
    {
        if (doHorizontal != null)
        {
            StopCoroutine(doHorizontal);
        }
    }

    public void EndMoveVertical(float direction)
    {
        if(doVertical != null)
        {
            StopCoroutine(doVertical);
        }
    }
    private IEnumerator DoMoveHorizontal(float direction)
    {
        while (true)
        {
            Vector3 currentPos = transform.position;
            currentPos.x += direction * speed * Time.deltaTime;
            rb.MovePosition(currentPos);
            yield return null;
        }
    }
    private IEnumerator DoMoveVertical(float direction)
    {
        while (true)
        {
            Vector3 currentPos = transform.position;
            currentPos.z += direction * speed * Time.deltaTime;
            rb.MovePosition(currentPos);
            yield return null;
        }
    }
}
