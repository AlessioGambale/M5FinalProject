using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [Header("Alert Settings")]
    [SerializeField] private bool _canAlert = true;
    [SerializeField] private float _alertRadius = 8f;
    [SerializeField] private int _maxAlliesToAlert = 5;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] protected TargetDetection _targetDetection;
    [SerializeField] protected float _destinationGap;
    [SerializeField] private Transform _overlapOrigin;

    private Collider[] _allies;
    protected NavMeshAgent _agent;
    private AnimationParamHandler _animationParamHandler;
    public bool IsAlerted { get; set; }
    public bool CanBeAlerted { get; set; } = true;

    public float DestinationGap => _destinationGap;

    public TargetDetection TargetDetection => _targetDetection;
    public NavMeshAgent Agent => _agent;

    private void Start()
    {
        EnemyManager.Instance.AddEnemy(this);
    }
    private void Awake()
    {
        _allies = new Collider[_maxAlliesToAlert];
        _agent = GetComponent<NavMeshAgent>();
        _animationParamHandler = GetComponent<AnimationParamHandler>();
    }

    private void Update()
    {
        _animationParamHandler.SetForward(_agent.velocity.magnitude);
    }

    public abstract void HandlePatrol();
    public void AlertAllies(Vector3 position)
    {
        if (!_canAlert) return;

        int count = Physics.OverlapSphereNonAlloc(_overlapOrigin.position, _alertRadius, _allies, _enemyLayer);
        Debug.Log(count);

        for (int i = 0; i < count; i++)
        {
            Collider ally = _allies[i];
            
            if (ally.TryGetComponent<Enemy>(out var enemy) && enemy != this)
            {
                enemy.ReceiveAlert(position);
            }
        }
    }

    public void ReceiveAlert(Vector3 position)
    {
        if (!CanBeAlerted) return;

        _agent.SetDestination(position);
        IsAlerted = true;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_overlapOrigin.position, _alertRadius);
    }
}

