using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private SO_GenericItem _genericItem;

    private bool IsInside = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        IsInside = true;
    }

    private void Update()
    {
        if (!IsInside) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.AddItem(_genericItem);

            Destroy(gameObject);
        }
    }
}
