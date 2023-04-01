using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    public Vector3 positionOffsetHouse;
    public Vector3 positionOffsetMill;
    public Vector3 positionOffsetSmallHouse;
    public Vector3 positionOffsetTree;
    public Vector3 positionOffsetMaslo;
    public Vector3 rotationHouseOffset;
    
    
    [Header("Optional")]

    public HouseBlueprint building;

    private MeshRenderer rend;
    private Color startColor;

    BuildManager buildManager;

    public Vector3 GetHousePosition()
    {
        return transform.position + positionOffsetHouse;
    }

    public Vector3 GetMillPosition()
    {
        return transform.position + positionOffsetMill;
    }

    public Vector3 GetSmallHousePosition()
    {
        return transform.position + positionOffsetSmallHouse;
    }
    
    public Vector3 GetTreePosition()
    {
        return transform.position + positionOffsetTree;
    }

    public Vector3 GetMasloPosition()
    {
        return transform.position + positionOffsetMaslo;
    }
    
    
    void Start()
    {
        rend = GetComponentInChildren<MeshRenderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        if(building != null)
        {
            building = (HouseBlueprint)Instantiate(building, GetTreePosition(), Quaternion.identity);
            if(building.CompareTag("house"))
            {
                building.transform.position = GetHousePosition();
                building.transform.Rotate(rotationHouseOffset.x, rotationHouseOffset.y, rotationHouseOffset.z);
            }
        }
        
    }

    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(!buildManager.CanBuild)
            return;
        if(building != null)
        {
            Debug.Log("Can't build there!");
            
            return;
        }
        
        buildManager.BuildBuildingOn(this);
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        rend.material.color = hoverColor; 
        // if(!buildManager.CanBuild)
        //     return;
        
        // if(buildManager.HasMoney)
        // {
        //     rend.material.color = hoverColor; 
        // }
        // else
        // {
        //     rend.material.color = notEnoughMoneyColor;
        // }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
