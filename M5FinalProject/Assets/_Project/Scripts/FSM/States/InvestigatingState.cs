using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigatingState : FSM_BaseState
{
    [SerializeField] private float _searchDuration;
    [SerializeField] private float _stopDuration;
    [SerializeField] private float _lookAngle;
    [SerializeField] private float _rotationSpeed;
    private int _direction = 1;
    private float _currentAngle;
    private float _stopTimer;
    private bool _hasReachedPoint;
    private float _searchTimer;

    public bool HasInvestigateEnded => _hasReachedPoint && _searchTimer >= _searchDuration;
    public override void OnStateEnter()
    {
        _currentAngle = 0;
        _hasReachedPoint = false;
        _searchTimer = 0;
        _direction = 1;
        _enemy.Agent.isStopped = false;
        _enemy.TargetDetection.ResetVision();
        _enemy.CanBeAlerted = false;
    }
    public override void OnStateExit()
    {
        _enemy.CanBeAlerted = true;
    }
    private void Rotate()
    {
        if (_stopTimer > 0)
        {
            _stopTimer -= Time.deltaTime;
            return;
        }
        _searchTimer += Time.deltaTime;
        float rotationStep = _rotationSpeed * Time.deltaTime * _direction;
        _enemy.transform.Rotate(Vector3.up , rotationStep);
        _currentAngle += rotationStep;
        if (Mathf.Abs(_currentAngle) >= _lookAngle)
        {
            _direction *= -1;
            _currentAngle = Mathf.Sign( _currentAngle ) * _lookAngle;
            _stopTimer = _stopDuration;
        }
    }

    public override void StateUpdate()
    {
       if (!_hasReachedPoint)
       {
            if (!_enemy.Agent.pathPending && _enemy.Agent.remainingDistance <= _enemy.DestinationGap)
            {
                _hasReachedPoint = true;
                _enemy.Agent.isStopped = true;
            }
       }
       else
       {
            Rotate();
       }
    }
}

