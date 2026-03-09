using UnityEngine;

public class OnAnimationEvent : MonoBehaviour
{
    public void OnPlayerStep()
    {
        SoundManager.Instance.PlayPlayerSteps();
    }
    public void OnDoorOpen()
    {
        SoundManager.Instance.PlayDoor();
    }
}
