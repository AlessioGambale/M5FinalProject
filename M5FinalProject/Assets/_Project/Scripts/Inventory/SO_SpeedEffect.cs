using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class SO_SpeedEffect : SO_Effect
{
    [SerializeField] private float _multiplier;
    [SerializeField] private float _duration;
    public override void Apply(GameObject user)
    {
        if (!user.TryGetComponent<NavMeshAgent>(out var agent)) return;
       
        if (!user.TryGetComponent<MonoBehaviour>(out var mono)) return;  

        mono.StartCoroutine(ApplySpeedBoost(agent));
    }

    private IEnumerator ApplySpeedBoost(NavMeshAgent agent)
    {
        agent.speed *= _multiplier;
        yield return new WaitForSeconds(_duration);
        agent.speed /= 1;
    }
}
