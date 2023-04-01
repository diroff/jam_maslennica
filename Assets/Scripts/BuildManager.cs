using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public Vector3 rotationHouseOffset;
    public Vector3 rotationMillOffset;
    public Vector3 rotationSmallHouseOffset;
    private HouseBlueprint houseToBuild;
    public static BuildManager instance;
    public HouseBlueprint house;
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BM in scene!");
            return;
        }
        instance = this;
        
    }

    

    //public GameObject buildingPrefab;


    public bool CanBuild{get{ return houseToBuild != null;}}
    // public bool HasMoney{get{ return PlayerStats.Money >= turretToBuild.cost;}}
    

    public void BuildBuildingOn(Node node)
    {
        if(PlayerStats.Money < houseToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStats.Money -= houseToBuild.cost;
        HouseBlueprint building = (HouseBlueprint)Instantiate(houseToBuild, node.GetMasloPosition(), Quaternion.identity);
        if(building.CompareTag("maslo"))
        {
            building.transform.position = transform.position + node.GetMasloPosition();
        }
        // if(building.CompareTag("house"))
        // {
        //     building.transform.Rotate(rotationHouseOffset.x, rotationHouseOffset.y, rotationHouseOffset.z);
        // }
        if(building.CompareTag("mill"))
        {
            building.transform.position = transform.position + node.GetMillPosition();
            building.transform.Rotate(rotationMillOffset.x, rotationMillOffset.y, rotationMillOffset.z);
        }
        if(building.CompareTag("small house"))
        {
            building.transform.position = transform.position + node.GetSmallHousePosition();
            building.transform.Rotate(rotationSmallHouseOffset.x, rotationSmallHouseOffset.y, rotationSmallHouseOffset.z);
        }
        
        node.building = building;
    }

    public void SelectHouseToBuild(HouseBlueprint house)
    {
        houseToBuild = house;
    }
}
