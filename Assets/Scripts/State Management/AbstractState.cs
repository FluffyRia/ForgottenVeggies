using UnityEngine;
/// <summary>
/// Defines a base template for the states.
/// I use states only to trigger events and turn on or turn off certain behaviors.
/// States themselves don't contain information and methods of the behaviors.
/// </summary>
public abstract class AbstractState : MonoBehaviour
{
    public abstract void EnterState(AbstractStateManager stateManager);
    public abstract void UpdateState(AbstractStateManager stateManager);
    public abstract void ExitState(AbstractStateManager stateManager);
}
