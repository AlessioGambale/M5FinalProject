using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSM_BaseState
{
    public override void OnStateEnter()
    {
        _enemy.TargetDetection.SetVision(1.5f , 1.2f);
    }

    public override void OnStateExit()
    {
        
    }

    public override void StateUpdate()
    {
        _enemy.Agent.isStopped = false;
        _enemy.Agent.SetDestination(_enemy.TargetDetection.Target.position);
    }
}
