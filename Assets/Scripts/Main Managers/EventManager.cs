using System;
using UnityEngine;

/// <summary>
/// Manager of the events. You can subscribe to/invoke events by refering to an instance of this manager!
/// </summary>
public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) return;
        
        Instance = this;
    }


    #region Player Input Events

    /// <summary>
    /// Subscribe to this Event to react on whenever player presses jump button!
    /// </summary>
    public event Action OnPlayerJump;
    
    /// <summary>
    /// Invoke this method to invoke all the methods subscribed to OnPlayerJump event!
    /// </summary>
    public void PlayerJump()
    {
        print("Jumped");
        if (OnPlayerJump != null) OnPlayerJump();
    }

    /// <summary>
    /// Subscribe to this Event to react on whenever player presses interact button!
    /// </summary>
    public event Action OnPlayerInteract;

    /// <summary>
    /// Invoke this method to invoke all the methods subscribed to OnPlayerInteract event!
    /// </summary>
    public void PlayerInteract()
    {
        print("Interacted");
        if (OnPlayerInteract != null) OnPlayerInteract();
    }

    /// <summary>
    /// Subscribe to this Event to react on whenever player starts Sprinting
    /// </summary>
    public event Action OnPlayerStartedRunning;
    /// <summary>
    /// Subscribe to this Event to react on whenever player stops Sprinting
    /// </summary>
    public event Action OnPlayerStoppedRunning;

    /// <summary>
    /// Invoke this method to invoke all the methods subscribed to OnPlayerJump event!
    /// </summary>
    public void PlayerStartRunning()
    {
        
        if (OnPlayerStartedRunning != null) OnPlayerStartedRunning();
    }

    /// <summary>
    /// Invoke this method to invoke all the methods subscribed to OnPlayerJump event!
    /// </summary>
    public void PlayerStopRunning()
    {
        
        if (OnPlayerStoppedRunning != null) OnPlayerStoppedRunning();
    }

    #endregion


    #region Game Input Events
    /// <summary>
    /// Subscribe to this event to react on whenever the exit button is being pressed 
    /// </summary>
    public event Action OnExitPressed;
    /// <summary>
    /// Invoke this method to invoke all the methods subscribed to OnExitPressed event!
    /// </summary>
    public void ExitPressed()
    {
        if(OnExitPressed != null) OnExitPressed();
    }
    #endregion
}
