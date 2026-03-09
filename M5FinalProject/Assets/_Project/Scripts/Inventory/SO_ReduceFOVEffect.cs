using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ReduceFOV")]
public class SO_ReduceFOVEffect :SO_Effect
{
    [SerializeField] private float _angleMultiplier;
    [SerializeField] private float _distanceMultiplier;
    [SerializeField] private float _duration;

    public override void Apply(GameObject user)
    {
        if (!user.TryGetComponent<MonoBehaviour>(out var mono)) return;

        mono.StartCoroutine(ApplyReduceFOV());
    }
       
    private IEnumerator ApplyReduceFOV()
    {
        foreach (var enemy in EnemyManager.Instance.Enemies)
        {
            enemy.TargetDetection.SetVision(_angleMultiplier, _distanceMultiplier);
        }

        yield return new WaitForSeconds(_duration);

        foreach (var enemy in EnemyManager.Instance.Enemies)
        {
            enemy.TargetDetection.ResetVision();
        }
    }
}
