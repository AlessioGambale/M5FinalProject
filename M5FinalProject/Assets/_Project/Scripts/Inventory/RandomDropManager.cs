using UnityEngine;

public class RandomDropManager : MonoBehaviour
{
    [SerializeField] private DropItem[] _dropItems;

    public static RandomDropManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void GetRandomDrop()
    {
        float randomNum = Random.Range(0f, 100f);
        float accumulatedChance = 0f;

        foreach (var dropItem in _dropItems)
        {
            accumulatedChance += dropItem.DropChance;

            if (randomNum < accumulatedChance)
            {
                InventoryManager.Instance.AddItem(dropItem.PowerUpItem);
                return;
            }
        }

    }
}
