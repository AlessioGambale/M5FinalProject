using System.Collections;
using UnityEngine;

public class WayPointEnemy : Enemy
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _waitTime;
    
    private int _currentIndex;
    private bool _isWaiting  = false;

    public override void HandlePatrol()
    {
       if (_wayPoints.Length == 0 || _isWaiting) return;
       if (_agent.remainingDistance <= _destinationGap)
       {
            StartCoroutine(Wait());
       }
    }

    private void UpdateIndex()
    {
        _currentIndex = (_currentIndex + 1) % _wayPoints.Length;
    }

    private void ReachWayPoint()
    {
        _agent.SetDestination(_wayPoints[_currentIndex].position);
    }
    private IEnumerator Wait()
    {
        _isWaiting = true;
        _agent.isStopped = true;

        yield return new WaitForSeconds(_waitTime);

        _isWaiting = false;
        _agent.isStopped = false;

        UpdateIndex();
        ReachWayPoint();
    }
   
}
