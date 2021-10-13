using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MoveScript))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerController controller;
    private MoveScript moveScript;
    private void Start()
    {
        animator = GetComponent<Animator>();
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

        if (direction > 0)
        {
            animator.Play("Player_Move_Right");
        }
        else
        {
            animator.Play("Player_Move_Left");
        }
    }

    public void MoveVertical(float direction)
    {
        if (direction > 0)
        {
            animator.Play("Player_Move_Back");
        }
        else
        {
            animator.Play("Player_Move_Front");
        }
    }

    public void EndMoveHorizontal(float direction)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Front") &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Back"))
        {
            animator.Play("Player_Idle");
        }
    }

    public void EndMoveVertical(float direction)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Right") &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Left"))
        {
            animator.Play("Player_Idle");
        }
    }
}
