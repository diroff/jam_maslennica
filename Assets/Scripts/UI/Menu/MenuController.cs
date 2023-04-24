using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private bool _isStartOpened = true;
    [SerializeField] private Menu _startMenu;

    private Menu _currentMenu;
    private Menu _nextMenu;

    private void Start()
    {
        if (!_isStartOpened)
            return;

        _currentMenu = _startMenu;
        OpenMenu(_currentMenu);
    }

    public void OpenMenu(Menu menu)
    {
        _currentMenu.SetMenuState(false);
        _nextMenu = menu;
        _nextMenu.SetPreviousRoom(_currentMenu);
        _nextMenu.SetMenuState(true);
        _currentMenu = _nextMenu;
    }

    public void CloseMenu()
    {
        _currentMenu.SetMenuState(false);
        _nextMenu = _currentMenu.PreviousMenu;
        _nextMenu.SetMenuState(true);
        _currentMenu = _nextMenu;
    }
}