using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeathDamage : MonoBehaviour
{
    [SerializeField] private int _damageAmount;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<LifeController>(out var lifeController)) return;
        
        lifeController.TakeDamage(_damageAmount);
    }

}
