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
        InputManager.Instance.PlayerControls.Lumina.Pause.performed += Pause;
    }

    private void OnDisable()
    {
        InputManager.Instance.PlayerControls.Lumina.Left.performed -= MoveLeft;
        InputManager.Instance.PlayerControls.Lumina.Right.performed -= MoveRight;
        InputManager.Instance.PlayerControls.Lumina.Jump.performed -= Jump;
        InputManager.Instance.PlayerControls.Lumina.Crouch.performed -= Crouch;
        InputManager.Instance.PlayerControls.Lumina.Ability.performed -= Ability;
        InputManager.Instance.PlayerControls.Lumina.Pause.performed -= Pause;
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
            DecreaseFillOverTime.Instance.ChangeColor(true);
            inverted = true;
        }
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        if(inverted)
        {
            gameObject.transform.position = PathNodes.Instance.m_nodes[currentPath -= 3].position;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            DecreaseFillOverTime.Instance.ChangeColor(false);
            inverted = false;
        }
    }

    private void Ability(InputAction.CallbackContext context)
    {
        
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if(GameManager.Instance.gameState == GameState.Start)
        {
            GameManager.Instance.gameState = GameState.Paused;
            Time.timeScale = 0.0f;
            GameManager.Instance.pauseEvent.Invoke();
            return;
        }
        
        if(GameManager.Instance.gameState == GameState.Paused)
        {
            GameManager.Instance.gameState = GameState.Start;
            Time.timeScale = 1.0f;
            GameManager.Instance.unpauseEvent.Invoke();
            return;
        }
    }
}
