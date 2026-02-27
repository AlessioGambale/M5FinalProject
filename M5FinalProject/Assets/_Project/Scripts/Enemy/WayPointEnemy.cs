using UnityEngine;

public class WayPointEnemy : Enemy
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _waitTime;
    
    public override void HandlePatrol()
    {
       
    }
  
}
