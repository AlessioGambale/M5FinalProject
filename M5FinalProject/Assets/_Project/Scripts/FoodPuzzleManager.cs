using UnityEngine;
using UnityEngine.Events;

public class FoodPuzzleManager : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private GameObject _puzzleUI;
    [SerializeField] private UnityEvent _onPuzzleSolved;
    [SerializeField] private GameObject _choiceUI;

    [SerializeField] private string[] _pizzaSpeakers;
    [SerializeField] private string[] _pizzaTexts;
    [SerializeField] private float[] _pizzaDurations;

    [SerializeField] private string[] _hotDogSpeakers;
    [SerializeField] private string[] _hotDogTexts;
    [SerializeField] private float[] _hotDogDurations;

    [SerializeField] private string[] _eggSpeakers;
    [SerializeField] private string[] _eggTexts;
    [SerializeField] private float[] _eggDurations;

    private bool _isPuzzleSolved;

    public void ShowChoiceUI()
    {
        if (!_isPuzzleSolved)
            _choiceUI.SetActive(true);
    }

    private void SetDialogue(string[] speakers ,  string[] texts , float[] durations)
    {
        _dialogueManager.Speakers = speakers;
        _dialogueManager.DialogueText = texts;
        _dialogueManager.Durations = durations;
    } 

    public void SelectPizza()
    {
        SetDialogue (_pizzaSpeakers, _pizzaTexts , _pizzaDurations);
        _dialogueManager.StartDialogue();
    }

    public void SelectHotDog()
    {
        SetDialogue(_hotDogSpeakers,_hotDogTexts , _hotDogDurations);
        _dialogueManager.StartDialogue();
    }

    public void SelectEggSandwich()
    {
        _isPuzzleSolved = true;
        SetDialogue(_eggSpeakers , _eggTexts , _eggDurations);
        _dialogueManager.StartDialogue();
        _onPuzzleSolved?.Invoke();
    }



}
