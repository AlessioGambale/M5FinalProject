using UnityEngine;

public class AnimationParamHandler : MonoBehaviour
{
    [SerializeField] private string _isBuildingName = "isBuilding";
    [SerializeField] private string _forwardName = "Forward";
    [SerializeField] private string _floatingName = "Floating";
    [SerializeField] private string _isOpenName = "IsOpen";
    [SerializeField] private string _isPulledName = "IsPulled";
    [SerializeField] private string _isCompletedName = "IsCompleted";
    [SerializeField] private string _isInsideName = "IsInside";

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
    public void SetPulled()
    {
        _animator.SetTrigger(_isPulledName);
    }
    public void OpenChest()
    {
        _animator.SetTrigger(_isCompletedName);
    }
    public void OnIsInside()
    {
        _animator.SetTrigger(_isInsideName);
    }

}
