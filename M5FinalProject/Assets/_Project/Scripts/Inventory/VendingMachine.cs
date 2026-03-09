using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] private RandomDropManager _randomDropManager;
    private bool _isInTrigger = false;
    private bool _canDrop = true;

    private void Update()
    {
        if (!_isInTrigger) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (!_canDrop) return;
        RandomDropManager.Instance.GetRandomDrop();
        _canDrop = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _isInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _isInTrigger = false;
    }
}
