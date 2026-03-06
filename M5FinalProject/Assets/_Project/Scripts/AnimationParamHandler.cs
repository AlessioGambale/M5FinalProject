using UnityEngine;

public class AnimationParamHandler : MonoBehaviour
{
    [SerializeField] private string _isBuildingName = "isBuilding";
    [SerializeField] private string _forwardName = "Forward";
    [SerializeField] private string _floatingName = "Floating";
    [SerializeField] private string _isOpenName = "IsOpen";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void SetForward(float speed)
    {
        _animator.SetFloat(_forwardName , speed);
    }
    public void SetIsBuilding()
    {
        _animator.SetTrigger(_isBuildingName);
    }
    public void Floating()
    {
        _animator.SetTrigger(_floatingName);
    }
    public void Open()
    {
        _animator.SetTrigger(_isOpenName);
    }
}
