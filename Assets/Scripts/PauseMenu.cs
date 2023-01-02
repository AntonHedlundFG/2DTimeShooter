using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas _pauseMenu;

    [SerializeField] private KeyCode _pauseButton;
    [SerializeField] private GamePauseSystem _pauseSystem;

    private void Update()
    {
        CheckPauseKey();
    }

    private void CheckPauseKey()
    {
        if (!Input.GetKeyDown(_pauseButton))
        {
            return;
        }
        if(_pauseSystem.GetPauseState() == GamePauseSystem.PauseStates.Pause)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    private void Awake()
    {
        _pauseMenu.enabled = false;
    }

    public void PauseGame()
    {
        _pauseSystem.SetState(GamePauseSystem.PauseStates.Pause);
        _pauseMenu.enabled = true;
    }

    public void ResumeGame()
    {
        _pauseSystem.SetState(GamePauseSystem.PauseStates.Play);
        _pauseMenu.enabled = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
