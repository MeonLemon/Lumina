using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private int currentPath;
    private bool inverted;
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
        InputManager.Instance.PlayerControls.Lumina.Ability.performed += Ability;
    }

    private void OnDisable()
    {
        InputManager.Instance.PlayerControls.Lumina.Left.performed -= MoveLeft;
        InputManager.Instance.PlayerControls.Lumina.Right.performed -= MoveRight;
        InputManager.Instance.PlayerControls.Lumina.Jump.performed -= Jump;
        InputManager.Instance.PlayerControls.Lumina.Crouch.performed -= Crouch;
        InputManager.Instance.PlayerControls.Lumina.Ability.performed -= Ability;
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (!inverted)
        {
            if (currentPath - 1 < 0) return;
            gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath -= 1].position;
        }
        else
        {
            if (currentPath - 1 < 3) return;
            gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath -= 1].position;
        }
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        if (!inverted)
        {
            if (currentPath + 1 > 2) return;
            gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath += 1].position;
        }
        else
        {
            if (currentPath + 1 > 5) return;
            gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath += 1].position;
        }    
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (!inverted)
        {
            gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath += 3].position;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180f);
            inverted = true;
        }
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        if(inverted)
        {
            gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath -= 3].position;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            inverted = false;
        }
    }

    private void Ability(InputAction.CallbackContext context)
    {
        
    }
}
