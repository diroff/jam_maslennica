using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private float _baseTime;
    [SerializeField] private int _moneyCount;

    private float _currentTime;

    private float _counter;
    private Node _nodePlacement;
    private PlayerStats _player;

    private bool _hasHouse = false;

    private void Start()
    {
        _player = PlayerStats.Player;
        _nodePlacement = GetComponent<HouseBlueprint>().PlacementNode;
        _nodePlacement.AbilityCountChanged.AddListener(HasHouse);
        _hasHouse = _nodePlacement.CountOfAbility > 0;
    }

    private void OnDisable()
    {
        _nodePlacement.AbilityCountChanged.RemoveListener(HasHouse);
    }

    private void Update()
    {
        CollectingMoney();
    }

    private void CollectingMoney()
    {
        if (!_hasHouse)
            return;

        CalculateTime();
        if (_counter >= _currentTime)
        {
            _player.AddMoney(_moneyCount);
            _counter = 0;
        }

        _counter += Time.deltaTime;
    }

    private void CalculateTime()
    {
        _currentTime = _baseTime - (_nodePlacement.CountOfAbility * 2);
    }

    private void HasHouse(bool hasHouse)
    {
        _hasHouse = hasHouse;
    }
}