using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public AIDestinationSetter aiDest;
    public AttackState attack;

    private void Update()
    {
        RunStateMachine();

        if (currentState == attack)
        {
            aiDest.OutOfRange();
        }
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
