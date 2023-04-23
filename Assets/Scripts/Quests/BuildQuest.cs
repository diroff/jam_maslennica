using UnityEngine;

public class BuildQuest : Quest
{
    [SerializeField] private BuildManager _buildManager;
    [SerializeField] private HouseBlueprint _houseToBuilding;

    private void OnEnable()
    {
        _buildManager.HouseBuilded.AddListener(AddBuild);
    }

    private void OnDisable()
    {
        _buildManager.HouseBuilded.RemoveListener(AddBuild);
    }

    private void AddBuild(HouseBlueprint houseType)
    {
        if (_houseToBuilding == houseType)
            AddValue(1);
    }
}