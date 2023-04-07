using UnityEngine;
using UnityEngine.UI;

public class Blin : MonoBehaviour
{
    [SerializeField] private Text _moneyCount;
    private PlayerStats _player;

    private void Awake()
    {
        _player = PlayerStats.Player;
    }

    private void OnEnable()
    {
        _player.CountOfMoneyChanged.AddListener(DisplayMoneyCount);
    }

    private void OnDisable()
    {
        _player.CountOfMoneyChanged.RemoveListener(DisplayMoneyCount);
    }

    private void DisplayMoneyCount(int count)
    {
        _moneyCount.text = count.ToString();
    }
}