using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected TargetDetection _targetDetection;
    protected NavMeshAgent _agent;

    public TargetDetection TargetDetection => _targetDetection;
    public NavMeshAgent Agent => _agent;

    private void Awake()
    {
      _agent = GetComponent<NavMeshAgent>();
    }

    public abstract void HandlePatrol(); 
}

