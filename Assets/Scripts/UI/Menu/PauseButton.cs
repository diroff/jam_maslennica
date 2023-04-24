using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void SetPauseState(bool enabled)
    {
        _pauseMenu.SetActive(enabled);
    }
}