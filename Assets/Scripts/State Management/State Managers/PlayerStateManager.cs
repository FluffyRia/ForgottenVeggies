using System;
using UnityEngine;

public class PlayerStateManager : AbstractStateManager
{
    #region Base Implementation
    protected override void Start()
    {
        p_currentState = WalkingState;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    
    protected override void SwitchState(AbstractState newState)
    {
        p_currentState.ExitState(this);
        base.SwitchState(newState);
    }
    #endregion
    public PlayerWalkingState WalkingState { get; private set; }
    public PlayerRunningState RunningState { get; private set; }
    public PlayerJumpingState JumpingState { get; private set; }


    private void Awake()
    {
        WalkingState = new PlayerWalkingState();
        RunningState = new PlayerRunningState();
        JumpingState = new PlayerJumpingState();

        //Subscribing to these events so player can run when holding shift and walk when not
        EventManager.Instance.OnPlayerStartedRunning += SwitchToRunning;
        EventManager.Instance.OnPlayerStoppedRunning += SwitchToWalking;
    }
    private void SwitchToWalking()
    {        
        SwitchState(WalkingState);
    }
    private void SwitchToRunning()
    {
        SwitchState(RunningState);
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerStartedRunning -= SwitchToRunning;
        EventManager.Instance.OnPlayerStoppedRunning -= SwitchToWalking;
    }
}
