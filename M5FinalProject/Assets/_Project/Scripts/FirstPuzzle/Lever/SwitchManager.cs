using UnityEngine;
using UnityEngine.Events;

public class SwitchManager : MonoBehaviour
{
    [SerializeField] private InteractableSwitch[] _switches;
    [SerializeField] private int _requiredActivations = 3;
    [SerializeField] private UnityEvent _onSwitchActivated;

    private int _currentCount = 0;

    private void OnEnable()
    {
        foreach (var switchItem in _switches)
        {
            switchItem.OnActivated += HandleSwitchActivated;
        }
    }

    private void OnDisable()
    {

        foreach (var switchItem in _switches)
        {
            switchItem.OnActivated -= HandleSwitchActivated;
        }
    }
    private void HandleSwitchActivated()
    {
        _currentCount++;
        Debug.Log(_currentCount);
        if (_currentCount >= _requiredActivations)
        {
            Debug.Log("LucaMangaka");
            _onSwitchActivated?.Invoke();
        }
    }
}
