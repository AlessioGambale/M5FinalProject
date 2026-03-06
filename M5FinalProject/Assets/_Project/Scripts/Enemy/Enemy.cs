using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected TargetDetection _targetDetection;
    [SerializeField] protected float _destinationGap;
    protected NavMeshAgent _agent;
    private AnimationParamHandler _animationParamHandler;

    public float DestinationGap => _destinationGap;

    public TargetDetection TargetDetection => _targetDetection;
    public NavMeshAgent Agent => _agent;

    private void Awake()
    {
      _agent = GetComponent<NavMeshAgent>();
        _animationParamHandler = GetComponent<AnimationParamHandler>();
    }

    private void Update()
    {
        _animationParamHandler.SetForward(_agent.velocity.magnitude);
    }

    public abstract void HandlePatrol(); 
}

