using UnityEngine;
/// <summary>
/// Base implementation of a state manager. I made it abstract
/// so later I can make different state managers that can be upcasted.
/// </summary>
public class AbstractStateManager : MonoBehaviour
{
    protected AbstractState p_currentState;

    /// <summary>
    /// Enters Initial state using EnterState() of a p_currentState that needs to be set up above base implementation!!!
    /// </summary>
    protected virtual void Start()
    {
        p_currentState.EnterState(this);
    }
    /// <summary>
    /// Updates p_currentState using UpdateState() method of a State class
    /// </summary>
    protected virtual void Update()
    {
        p_currentState.UpdateState(this);
    }
    /// <summary>
    /// Base Implementation p_currentState enters a new state provided as an argument!
    /// </summary>
    /// <param name="newState">Takes an argument of a type: Abstract State. And will enter it using EnterState() method</param>
    protected virtual void SwitchState(AbstractState newState)
    {
        p_currentState = newState;
        newState.EnterState(this);
    }
}
