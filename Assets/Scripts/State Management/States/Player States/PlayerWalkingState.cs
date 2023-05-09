using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Manipulates Walking Behavior
/// </summary>
public class PlayerWalkingState : AbstractState
{
    private PlayerWalkingBehavior _walkingBeh;
    public override void EnterState(AbstractStateManager stateManager)
    {
        _walkingBeh = stateManager.GetComponent<PlayerWalkingBehavior>();
        _walkingBeh.enabled = true;
    }
    public override void UpdateState(AbstractStateManager stateManager)
    {
    }
    public override void ExitState(AbstractStateManager stateManager)
    {
        _walkingBeh.enabled = false;
    }
}
