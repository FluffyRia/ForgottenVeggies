using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages main inputs, primarily for the player!
/// </summary>
public class InputManager : MonoBehaviour
{
    
    public InputManager Instance { get; private set; }

    private PlayerIA _playerIA;

    private void Awake()
    {
        if (Instance != null && Instance != this) return;

        Instance = this;
        _playerIA = GetComponent<PlayerIA>();
    }

    #region Player Inputs
    /// <summary>
    /// Get a value that can be used to manipulate the direction of the player
    /// </summary>
    /// <returns>Vector2 value of WASD or Gamepad's Left Stick</returns>
    public Vector2 PlayerGetDirection()
    {
        print(_playerIA.Main.Direction.ReadValue<Vector2>());
        return _playerIA.Main.Direction.ReadValue<Vector2>();
    }

    /// <summary>
    /// Get a value that can be used to manipulate camera for example.
    /// </summary>
    /// <returns>Vector2 value of a delta from mouse or from Gamepad's Right Stick.</returns>
    
    public Vector2 PlayerGetLook()
    {
        print(_playerIA.Main.Look.ReadValue<Vector2>());
        return _playerIA.Main.Look.ReadValue<Vector2>();
    }

    /// <summary>
    /// Fires a method from the event manager that can be used to manipulate the state of the jump!
    /// </summary>
    private void PlayerStartedRunning(InputAction.CallbackContext ctx)
    {
        print("Started Running");
    }

    /// <summary>
    /// Fires a method from the event manager that can be used to manipulate the state of the jump!
    /// </summary>
    private void PlayerStoppedRunning(InputAction.CallbackContext ctx)
    {
        print("Stopped Running"); 
    }

    /// <summary>
    /// Fires a method from the event manager that can be used to manipulate the state of the jump!
    /// </summary>
    private void PlayerJumped(InputAction.CallbackContext ctx)
    {
        print("Jumped");
    }
    #endregion

    #region Enable/Disable
    private void OnEnable()
    {
        _playerIA.Enable();
        _playerIA.FindAction("Jump").performed += PlayerJumped;
        _playerIA.FindAction("Run").performed += PlayerStartedRunning;
        _playerIA.FindAction("Run").canceled += PlayerStoppedRunning;
       
    }


    private void OnDisable()
    {
        _playerIA.FindAction("Jump").performed -= PlayerJumped;
        _playerIA.FindAction("Run").performed -= PlayerStartedRunning;
        _playerIA.FindAction("Run").canceled -= PlayerStoppedRunning;
        _playerIA.Disable();
        Instance = null;
    }
    #endregion
}
