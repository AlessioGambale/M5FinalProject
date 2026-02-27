using UnityEngine;

public abstract class FSM_BaseTransition : MonoBehaviour
{
    [SerializeField] private FSM_BaseState _targetState;

    protected FSM_BaseState _ownerState;
    protected FSM_Controller _controller;
    protected Enemy _enemy;

    public FSM_BaseState TargetState => _targetState;

    public virtual void SetUp(FSM_BaseState ownerState, FSM_Controller controller,Enemy owner)
    {
        _ownerState = ownerState;
        _controller = controller;
        _enemy = owner;
    }

    public abstract bool IsConditionMet();
}
