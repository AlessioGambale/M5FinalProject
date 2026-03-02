
public class LostTargetTransition : FSM_BaseTransition
{
    public override bool IsConditionMet()
    {
        return !_enemy.TargetDetection.CanSeeTarget();
    }
}
