
public class PatrolState : FSM_BaseState
{
    public override void OnStateEnter() 
    {
        _enemy.TargetDetection.ResetVision();
    }

    public override void StateUpdate()
    {
        _enemy.HandlePatrol();
    }

    public override void OnStateExit() { }
   
}
