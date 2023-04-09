using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;

    [SerializeField] private int _maximumAbility = 4;

    private Vector2Int _indexOfNode;
    private bool _hasEffect = false;
    private int _countOfAbility = 0;
    private BuildManager _buildManager;
    private float _darkness = 0f;

    public int CountOfAbility => _countOfAbility;
    public BuildManager BuildManager => _buildManager;
    public UnityEvent<bool> AbilityCountChanged;
    public float Darkness => _darkness;

    [Header("Optional")]

    public HouseBlueprint building;
    private MeshRenderer rend;
    private Color startColor;

    public HouseBlueprint GetHouse()
    {
        return building;
    }

    private void Start()
    {
        rend = GetComponentInChildren<MeshRenderer>();
        startColor = rend.material.color;
        _buildManager = BuildManager.instance;

        if(building != null)
        {
            building = Instantiate(building, transform.position, Quaternion.identity);
            building.transform.parent = transform;
            building.transform.localPosition = building.Position;
            building.transform.localRotation = Quaternion.Euler(building.Rotation);
        }

        _indexOfNode = GetComponent<PlacementTile>().TileIndex;
    }

    public Vector2Int GetNodeIndex()
    {
        return _indexOfNode;
    }

    public void AddAbility(int count)
    {
        _hasEffect = true;
        _countOfAbility += count;

        if(_countOfAbility > _maximumAbility)
            _countOfAbility = _maximumAbility;

        SetPointColor();
        AbilityCountChanged?.Invoke(_hasEffect);
    }

    public void SetPointColor()
    {
        if (_countOfAbility == 1)
            rend.material.color = Color.red;
        else if (_countOfAbility == 2)
            rend.material.color = Color.yellow;
        else if (_countOfAbility == 3)
            rend.material.color = Color.blue;
        else if (_countOfAbility == 4)
            rend.material.color = Color.green;
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(!_buildManager.CanBuild)
            return;
        if(building != null)
        {
            Debug.Log("Can't build there!");
            
            return;
        }
        
        _buildManager.BuildBuildingOn(this);
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if (_hasEffect)
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

    private void OnMouseExit()
    {
        if (_hasEffect)
            return;

        rend.material.color = startColor;
    }
}