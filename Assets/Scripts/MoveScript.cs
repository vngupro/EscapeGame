using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
//[RequireComponent(typeof(Animator))]
public class MoveScript : MonoBehaviour
{
    public float speed = 15.0f;

    private Coroutine doHorizontal;
    private Coroutine doVertical;
    private Rigidbody rb;
    //private Animator animator;
    [HideInInspector]
    public bool canMove = true;
    private PlayerController controller;
    public static MoveScript Instance { get; private set; }
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;

        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
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
        if (!canMove) { return; }

        //if(direction > 0)
        //{
        //    animator.Play("Player_Move_Right");
        //}
        //else
        //{
        //    animator.Play("Player_Move_Left");
        //}
      
        doHorizontal = StartCoroutine(DoMoveHorizontal(direction));
    }

    public void MoveVertical(float direction)
    {
        if (!canMove) { return; }
        //if (direction > 0)
        //{
        //    animator.Play("Player_Move_Back");
        //}
        //else
        //{
        //    animator.Play("Player_Move_Front");
        //}

        doVertical = StartCoroutine(DoMoveVertical(direction));
    }

    public void EndMoveHorizontal(float direction)
    {
        if (!canMove) { return; }
        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Front") &&
        //    !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Back"))
        //{
        //    animator.Play("Player_Idle");
        //}
   
        if (doHorizontal != null)
        {
            StopCoroutine(doHorizontal);
        }
    }

    public void EndMoveVertical(float direction)
    {
        if (!canMove) { return; }
        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Right") &&
        //    !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Left"))
        //{
        //    animator.Play("Player_Idle");
        //}

        if (doVertical != null)
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

    public void TriggerMove()
    {
        canMove = true;
    }

    public void StopMove()
    {
        if(doVertical != null)
        {
            StopCoroutine(doVertical);
        }

        if(doHorizontal != null)
        {
            StopCoroutine(doHorizontal);
        }
    }
}
