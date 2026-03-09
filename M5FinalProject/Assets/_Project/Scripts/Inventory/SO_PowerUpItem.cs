using UnityEngine;

[CreateAssetMenu(menuName = "Items/PowerUpItem")]
public class SO_PowerUpItem : SO_GenericItem
{
    [SerializeField] private SO_Effect _effect;
    public override void Use(GameObject user)
    {
        _effect.Apply(user);
        InventoryManager.Instance.RemoveItem(this);
    }
}
