using System;
using UnityEngine;
using UnityEngine.Events;
public class InteractableSwitch : MonoBehaviour
{
    [SerializeField] private UnityEvent _onActivated;
    [SerializeField] private bool _canRetrigger = false;
    
    public event Action OnActivated;

    private bool _isActive = false;
    private bool _isInside = false;
    private void Activate()
    {
        if (_isActive) return;
        _isActive = true;
        OnActivated?.Invoke();
        _onActivated?.Invoke();
        SoundManager.Instance.PlayLever();
    }

    private void Update()
    {
        if (!_isInside) return;
        if (_isActive) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Activate();

            if (_canRetrigger)  _isActive = false;  
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_isActive) return;
        if (other.CompareTag("Player"))
        {
           _isInside = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isActive) return;
        if (other.CompareTag("Player"))
        {
            _isInside = false;

        }
    }
}
