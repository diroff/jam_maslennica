using Flower;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public Vector3 rotationHouseOffset;
    public Vector3 rotationMillOffset;
    public Vector3 rotationSmallHouseOffset;
    private HouseBlueprint houseToBuild;
    public static BuildManager instance;
    public HouseBlueprint house;
    public HousePlacementArea Area;

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
            AddSquareEffect(node, 2);
        }
        
        node.building = building;
        node.building.transform.parent = node.transform;
    }

    private void AddSquareEffect(Node startPoint, int countMultiply) //countMultiply = количество слоев квадрата
    {
        for (int i = startPoint.GetNodeIndex().x - countMultiply; i <= startPoint.GetNodeIndex().x + countMultiply; i++)
        {
            if (i < 0 || i > Area.dimensions.x - 1)
                continue;

            for (int j = startPoint.GetNodeIndex().y - countMultiply; j <= startPoint.GetNodeIndex().y + countMultiply; j++)
            {
                if (j < 0 || j > Area.dimensions.y - 1)
                    continue;

                Area.m_Tiles[i, j].TakeNode().PleaseWork();
            }
        }
    }

    public void SelectHouseToBuild(HouseBlueprint house)
    {
        houseToBuild = house;
    }
}
