using UnityEngine;

public class FSM_Controller : MonoBehaviour
{
    [SerializeField] private FSM_BaseState _initialState;

    private FSM_BaseState _currentState;
    private FSM_BaseState[] _allStates;

    public Enemy Owner { get; private set; }

    private void Awake()
    {
        SetUp();
    }

    private void Start()
    {
        if (_initialState != null)
        {
            SetState(_initialState);
        }
    }

    private void SetUp()
    {
        _allStates = GetComponentsInChildren<FSM_BaseState>();
        Owner = GetComponentInParent<Enemy>(); 

        foreach (var state in _allStates)          
        {                                          
            state.SetUp(this, Owner);
        }
    }

    public void SetState(FSM_BaseState state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = state;
        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState == null) return;

        foreach (var transition in _currentState.Transitions)
        {
            if (transition.IsConditionMet())
            {
                SetState(transition.TargetState);
                break;
            }
        }

        _currentState.StateUpdate();
    }
}
