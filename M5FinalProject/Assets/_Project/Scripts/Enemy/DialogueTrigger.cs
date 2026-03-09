using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;

    [SerializeField] private AnimationParamHandler _paramHandler;

    [SerializeField] private CameraManager _cameraManager;

    [SerializeField] private int _cameraIndex;

    private bool _hasTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_hasTriggered)
        {
            _hasTriggered = true;
            _dialogueManager.StartDialogue();
            if (_paramHandler)
            {
                _paramHandler.OnIsInside();
            }
            _cameraManager.PlayCinematic(_cameraIndex);
        }
    }


}
