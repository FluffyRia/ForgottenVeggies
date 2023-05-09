using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages main inputs, primarily for the player!
/// </summary>
public class InputManager : MonoBehaviour
{
    
    public static InputManager Instance { get; private set; }

    private PlayerIA _playerIA;

    private void Awake()
    {
        if (Instance != null && Instance != this) return;

        Instance = this;
        _playerIA = new PlayerIA();
    }


    /// <summary>
    /// Subscribing a bunch of methods to invoke events from an event manager
    /// whenever a certain key is being pressed
    /// </summary>
    private void Start()
    {
        //Keys associated with the game itself
        _playerIA.FindAction("Exit").performed += ExitJustPressed;

        //Keys associated with player
        _playerIA.FindAction("Jump").performed += PlayerJumped;
        _playerIA.FindAction("Interact").performed += PlayerInteracted;
        _playerIA.FindAction("Run").performed += PlayerStartedRunning;
        _playerIA.FindAction("Run").canceled += PlayerStoppedRunning;
    }



    #region Player Inputs
    /// <summary>
    /// Get a value that can be used to manipulate the direction of the player
    /// </summary>
    /// <returns>Vector2 value of WASD or Gamepad's Left Stick</returns>
    public Vector2 PlayerGetDirection()
    {
        return _playerIA.Main.Direction.ReadValue<Vector2>();
    }

    /// <summary>
    /// Get a value that can be used to manipulate camera for example.
    /// </summary>
    /// <returns>Vector2 value of a delta from mouse or from Gamepad's Right Stick.</returns>
    
    public Vector2 PlayerGetLook()
    {
        Cursor.lockState = CursorLockMode.Locked;
        return _playerIA.Main.Look.ReadValue<Vector2>();
    }

    /// <summary>
    /// Invokes a method from the event manager that can be used to manipulate the state of the jump!
    /// </summary>
    private void PlayerStartedRunning(InputAction.CallbackContext ctx)
    {
        EventManager.Instance.PlayerStartRunning();
    }

    /// <summary>
    /// Invokes a method from the event manager that can be used to manipulate the state of the jump!
    /// </summary>
    private void PlayerStoppedRunning(InputAction.CallbackContext ctx)
    {
        EventManager.Instance.PlayerStopRunning();
    }

    /// <summary>
    /// Invokes a method from the event manager that can be used to manipulate the state of the jump!
    /// </summary>
    private void PlayerJumped(InputAction.CallbackContext ctx)
    {
        EventManager.Instance.PlayerJump();
    }

    /// <summary>
    /// Invokes a method from the event manager when player pressed the interact button
    /// </summary>
    private void PlayerInteracted(InputAction.CallbackContext ctx)
    {
        EventManager.Instance.PlayerInteract();
    }

    #endregion


    #region Game Inputs
    /// <summary>
    /// Invokes a method from the event manager when the Exit button is being pressed
    /// </summary>
    private void ExitJustPressed(InputAction.CallbackContext ctx)
    {
        EventManager.Instance.ExitPressed();
    }
    #endregion


    #region Enable/Disable
    private void OnEnable()
    {
        _playerIA.Enable();      
    }


    private void OnDisable()
    {
        _playerIA.FindAction("Jump").performed -= PlayerJumped;
        _playerIA.FindAction("Interact").performed -= PlayerInteracted;
        _playerIA.FindAction("Run").performed -= PlayerStartedRunning;
        _playerIA.FindAction("Run").canceled -= PlayerStoppedRunning;
        _playerIA.Disable();
        Instance = null;
    }
    #endregion
}
