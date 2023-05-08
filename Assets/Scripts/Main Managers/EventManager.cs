using System;
using UnityEngine;

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
    /// Subscribe to this Event to react on whenever player starts Sprinting
    /// </summary>
    public event Action OnPlayerStartedSprinting;
    /// <summary>
    /// Subscribe to this Event to react on whenever player stops Sprinting
    /// </summary>
    public event Action OnPlayerStoppedSprinting;

    /// <summary>
    /// Invoke this method to invoke all the methods subscribed to OnPlayerJump event!
    /// </summary>
    public void PlayerStartSprinting()
    {
        print("Started Running");
        if (OnPlayerStartedSprinting != null) OnPlayerStartedSprinting();
    }

    /// <summary>
    /// Invoke this method to invoke all the methods subscribed to OnPlayerJump event!
    /// </summary>
    public void PlayerStopSprinting()
    {
        print("Stopped Running");
        if (OnPlayerStoppedSprinting != null) OnPlayerStoppedSprinting();
    }

    #endregion 

}
