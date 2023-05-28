using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private int currentPath;
    [SerializeField] private Animator animator;

    private void Start()
    {
        currentPath = 1;
    }

    private void OnEnable()
    {
        InputManager.Instance.PlayerControls.Lumina.Left.performed += MoveLeft;
        InputManager.Instance.PlayerControls.Lumina.Right.performed += MoveRight;
        InputManager.Instance.PlayerControls.Lumina.Jump.performed += Jump;
        InputManager.Instance.PlayerControls.Lumina.Crouch.performed += Crouch;
    }

    private void OnDisable()
    {
        InputManager.Instance.PlayerControls.Lumina.Left.performed -= MoveLeft;
        InputManager.Instance.PlayerControls.Lumina.Right.performed -= MoveRight;
        InputManager.Instance.PlayerControls.Lumina.Jump.performed -= Jump;
        InputManager.Instance.PlayerControls.Lumina.Crouch.performed -= Crouch;
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (currentPath - 1 < 0) return;
        gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath -= 1].position;
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        if (currentPath + 1 > 2) return;
        gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath += 1].position;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Jump");
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Crouch");
    }
}
