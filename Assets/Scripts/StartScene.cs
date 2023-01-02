using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField] private GamePauseSystem _pauseSystem;

    private void Awake()
    {
        StartCoroutine(StartGameUnpause());
    }

    private IEnumerator StartGameUnpause()
    {
        _pauseSystem.SetState(GamePauseSystem.PauseStates.Pause);
        yield return new WaitForSeconds(3);
        _pauseSystem.SetState(GamePauseSystem.PauseStates.Play);
    }
}
