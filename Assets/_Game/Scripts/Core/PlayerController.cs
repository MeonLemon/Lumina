using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
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

    }

    private void MoveRight(InputAction.CallbackContext context)
    {

    }

    private void Jump(InputAction.CallbackContext context)
    {

    }

    private void Crouch(InputAction.CallbackContext context)
    {

    }
}
