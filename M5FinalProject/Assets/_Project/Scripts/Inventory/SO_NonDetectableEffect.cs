using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/NonDetectable")]
public class SO_NonDetectableEffect : SO_Effect
{
    [SerializeField] private float _duration;
    public override void Apply(GameObject user)
    {
        if (!user.TryGetComponent<MonoBehaviour>(out var mono)) return;
        mono.StartCoroutine(ApplyNonDetectableEffect());
    }

    private IEnumerator ApplyNonDetectableEffect()
    {
        
        foreach (var enemy in EnemyManager.Instance.Enemies)
        {
            enemy.TargetDetection.SetVision(0f , 0);
        }

        yield return new WaitForSeconds(_duration);

        foreach (var enemy in EnemyManager.Instance.Enemies)
        {
            enemy.TargetDetection.ResetVision();
        }
    }
}
