using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _cam;
    private AnimationParamHandler _animationParamHandler;
    
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animationParamHandler = GetComponent<AnimationParamHandler>();
        _cam = Camera.main;
    }

    private void Update()
    {
        HandleMovementInput();
        _animationParamHandler.SetForward(_agent.velocity.magnitude);
    }

    private void HandleMovementInput()
    {
        if (Input.GetMouseButtonDown (0))
        {
            Ray ray = _cam.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast(ray , out RaycastHit hitinfo))
            {
                _agent.SetDestination(hitinfo.point);
            }
        }
    }
}

