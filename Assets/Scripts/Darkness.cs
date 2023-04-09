using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    [SerializeField] private HousePlacementArea _house;
    [SerializeField] private Vector2Int _indexOfNode;
    [SerializeField] private PlacementTile[,] _tile;
    [SerializeField] private PlacementTile _infectedTile;
    [SerializeField] private float _timer;
    
    private void Start()
    {
        _tile = _house.m_Tiles;
        GetIndexesOfNodes();
    }
    private void GetIndexesOfNodes()
    {
        foreach(var tile in _tile)
        {
            _indexOfNode = tile.TileIndex;
            //Debug.Log(_indexOfNode);
        }

        
    }

    private void Update()
    {
        InfectionNode();
    }

    private void InfectionNode()
    {
        if (_timer >= 10f)
        {
            _timer = 0;
            _indexOfNode.x = Random.Range(0, _indexOfNode.x);
            _indexOfNode.y = Random.Range(0, _indexOfNode.y);
            _infectedTile = _house.m_Tiles[_indexOfNode.x, _indexOfNode.y];
            _infectedTile.SetState(PlacementTileState.Infected);
        }
        _timer += Time.deltaTime;
    }
            

}
