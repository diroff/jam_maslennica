using TMPro;
using UnityEngine;

public class Blin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyCount;
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