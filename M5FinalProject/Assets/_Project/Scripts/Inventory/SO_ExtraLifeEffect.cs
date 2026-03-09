using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ExtraLife")]
public class SO_ExtraLifeEffect : SO_Effect
{
    [SerializeField] private int _amount;
    public override void Apply(GameObject user)
    {
       if (!user.TryGetComponent<PlayerRespawn>(out  var playerRespawn)) return;

        playerRespawn.AddLife(_amount);
    }

}
