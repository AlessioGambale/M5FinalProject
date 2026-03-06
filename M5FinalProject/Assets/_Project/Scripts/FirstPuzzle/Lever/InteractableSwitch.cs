using System;
using UnityEngine;
public class InteractableSwitch : MonoBehaviour
{
    public event Action OnActivated;

    private bool _isActive = false;
    private bool _isInside = false;
    private void Activate()
    {
        if (_isActive) return;
        _isActive = true;
        OnActivated?.Invoke();
        Debug.Log("GiulioGay");
    }

    private void Update()
    {
        if (!_isInside) return;
        if (_isActive) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Activate();
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
}
