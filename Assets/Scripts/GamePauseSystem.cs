using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeMultiplier;

[CreateAssetMenu(fileName = "PauseStateHolder", menuName = "Pause State Holder")]
public class GamePauseSystem : ScriptableObject
{
    private PauseStates _pauseState;
    [SerializeField] private TMSystemHandler _tmSystemHandler;

    public enum PauseStates
    {
        Play,
        Pause
    }

    public PauseStates GetPauseState() => _pauseState;

    public void SetState(PauseStates newState)
    {
        if (_pauseState == newState) { return; }

        switch(newState)
        {
            case PauseStates.Play:
                OnPlay();
                break;
            case PauseStates.Pause:
                OnPause();
                break;
        }

        _pauseState = newState;
    }
    
    private void OnPlay()
    {
        _tmSystemHandler.GetBrain().SetPauseState(PauseStates.Play);
    }
    private void OnPause()
    {
        _tmSystemHandler.GetBrain().SetPauseState(PauseStates.Pause);
    }

}
