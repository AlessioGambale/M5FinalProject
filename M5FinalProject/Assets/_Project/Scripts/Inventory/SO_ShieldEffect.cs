using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ShieldEffect")]
public class SO_ShieldEffect : SO_Effect
{
    public override void Apply(GameObject user)
    {
        if (!user.TryGetComponent<LifeController>(out var lifeController)) return;

        lifeController.AddHp(2);
    }

}
