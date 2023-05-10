using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Manipulates Running Behavior
/// </summary>
public class PlayerRunningState : AbstractState
{
    
    private PlayerRunningBehavior _runningBeh;

    public override void EnterState(AbstractStateManager stateManager)
    {
        _runningBeh = stateManager.GetComponent<PlayerRunningBehavior>();
        _runningBeh.enabled = true;
    }
    public override void UpdateState(AbstractStateManager stateManager)
    {
    }
    public override void ExitState(AbstractStateManager stateManager)
    {
        _runningBeh.enabled = false;
    }


}
