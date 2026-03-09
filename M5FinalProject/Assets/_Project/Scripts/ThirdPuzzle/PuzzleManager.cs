using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PillarController[] _pillars;
    [SerializeField] private UnityEvent _onPuzzleSolved;

    public void Confirm()
    {
        foreach (var pillar in _pillars)
        {
            if (!pillar.IsCorrect)
            {
                pillar.Renderer.material = pillar.StartMaterial;
                
                
            }
            else
            {
                pillar.Renderer.material = pillar.Material;
                
            }
        }

        bool AllCorrect = _pillars.All(p => p.IsCorrect);

        if (AllCorrect)
        {
            _onPuzzleSolved.Invoke();
        }

        else
        {
            ResetPillars();
        }
        
    }

    private void ResetPillars()
    {
        foreach (var pillar in _pillars)
            pillar.ResetPillar();
    }

}
