using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEnemy : Enemy
{
    [SerializeField] private float _stopDuration;
    [SerializeField] private float _lookAngle;
    [SerializeField] private float _rotationSpeed;
    private int _direction = 1;
    private float _currentAngle;
    private float _stopTimer;


    private void Update()
    {
        HandlePatrol();
    }
    public override void HandlePatrol() 
    {

        Rotate();
    }

    private void Rotate()
    {
        if (_stopTimer > 0)
        {
            _stopTimer -= Time.deltaTime;
            return;
        }
       
        float rotationStep = _rotationSpeed * Time.deltaTime * _direction;
       transform.Rotate(Vector3.up, rotationStep);
        _currentAngle += rotationStep;
        if (Mathf.Abs(_currentAngle) >= _lookAngle)
        {
            _direction *= -1;
            _currentAngle = Mathf.Sign(_currentAngle) * _lookAngle;
            _stopTimer = _stopDuration;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        AlertAllies(_targetDetection.Target.position);
    }

}
