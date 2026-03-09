using System;
using UnityEngine;

[Serializable]
public class DropItem 
{
   [SerializeField] private SO_PowerUpItem _powerUpItem;
   [SerializeField] private float _dropChance;

    public SO_PowerUpItem PowerUpItem => _powerUpItem;
    public float DropChance => _dropChance;
}
