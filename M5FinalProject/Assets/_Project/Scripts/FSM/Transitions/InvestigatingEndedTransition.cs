using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigatingEndedTransition :FSM_BaseTransition
{
    [SerializeField] private InvestigatingState _investigatingState;

    public override bool IsConditionMet()
    {
     return _investigatingState.HasInvestigateEnded;
    }
}
