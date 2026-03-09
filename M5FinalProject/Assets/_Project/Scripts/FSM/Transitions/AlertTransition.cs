using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTransition : FSM_BaseTransition
{
    public override bool IsConditionMet()
    {
        return _enemy.IsAlerted;
    }
}
    

