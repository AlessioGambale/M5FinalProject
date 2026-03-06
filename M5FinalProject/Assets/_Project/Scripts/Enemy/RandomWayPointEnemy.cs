using UnityEngine;

public class RandomWayPointEnemy :WayPointEnemy
{
    protected override void UpdateIndex()
    {
        _currentIndex = Random.Range(0, _wayPoints.Length);
    }
}
