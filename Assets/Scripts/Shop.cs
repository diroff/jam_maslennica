using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public HouseBlueprint maslenica;
    public HouseBlueprint mill;
    public HouseBlueprint smallHouse;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectHouse()
    {
        Debug.Log("Maslenica Pusrchased");
        buildManager.SelectHouseToBuild(maslenica);
        
    }
    public void SelectMill()
    {
        Debug.Log("Mill Pusrchased");
        buildManager.SelectHouseToBuild(mill);
        
    }

    public void SelectSmallHouse()
    {
        Debug.Log("Small House Pusrchased");
        buildManager.SelectHouseToBuild(smallHouse);
        
    }

}
