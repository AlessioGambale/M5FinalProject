using UnityEngine;

public abstract class FSM_BaseState : MonoBehaviour
{
    protected FSM_Controller _controller;
    protected FSM_BaseTransition[] _transition;
    protected Enemy _enemy;

    public FSM_BaseTransition[] Transitions => _transition;

    public virtual void SetUp(FSM_Controller controller, Enemy owner) 
    {                                                                     
        _controller = controller;                                        
        _enemy = owner;                                                   
                                                                          
        _transition = GetComponents<FSM_BaseTransition>();

        foreach (var transition in _transition)
        {
            transition.SetUp(this, _controller, _enemy);
        }
    }

    public abstract void OnStateEnter();
    public abstract void StateUpdate();
    public abstract void OnStateExit();
}
