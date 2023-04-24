using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private Menu _previousMenu;

    public Menu PreviousMenu => _previousMenu;

    public void SetMenuState(bool open)
    {
        _menu.SetActive(open);
    }

    public void SetPreviousRoom(Menu menu)
    {
        _previousMenu = menu;
    }
}
