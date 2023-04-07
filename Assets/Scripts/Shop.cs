using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private HouseBlueprint _scareCrow;
    [SerializeField] private HouseBlueprint _mill;
    [SerializeField] private HouseBlueprint _smallHouse;

    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void SelectHouse()
    {
        Debug.Log("Maslenica Pusrchased");
        _buildManager.SelectHouseToBuild(_scareCrow);
    }

    public void SelectMill()
    {
        Debug.Log("Mill Pusrchased");
        _buildManager.SelectHouseToBuild(_mill);
    }

    public void SelectSmallHouse()
    {
        Debug.Log("Small House Pusrchased");
        _buildManager.SelectHouseToBuild(_smallHouse);
    }
}