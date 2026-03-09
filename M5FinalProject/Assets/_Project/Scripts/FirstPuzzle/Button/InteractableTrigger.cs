using UnityEngine;
using UnityEngine.Events;

public class InteractableTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggered;

    private bool isEnabled = false;
    private bool _isInside = false;
    public void EnableTrigger()
    {
        isEnabled = true;
    }

    private void Update()
    {
        if (!_isInside) return;
        if (!isEnabled) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            _onTriggered.Invoke();
            SoundManager.Instance.PlayButton();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isEnabled) return;
        if (other.CompareTag("Player"))
        {
            _isInside = true;
        }
    }
}
