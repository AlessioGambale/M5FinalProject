using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    [SerializeField] private RotateObject _rotateObject;
    [SerializeField] private int _maxInterations = 3;
    [SerializeField] private int _correctValue;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _material;

    public Material StartMaterial { get; private set; }
    public Renderer Renderer => _renderer;
    public Material Material => _material;


    private int _currentInterations = 0;
    public bool IsCorrect => _currentInterations == _correctValue;

    private void Start()
    {
        StartMaterial = _renderer.material;
    }
    public void Interact()
    {
        if (_currentInterations >= _maxInterations) return;
       
        _currentInterations++;
        _rotateObject.StartRotation();
        

    }

    public void ResetPillar()
    {
        _currentInterations = 0;
        _rotateObject.RotateBack();
       
    }
}
