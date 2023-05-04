using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    [SerializeField] private HousePlacementArea _house;
    [SerializeField] private Vector2Int _indexOfNode;
    [SerializeField] private PlacementTile[,] _tile;
    [SerializeField] private Node _infectedTile;
    [SerializeField] private Node _node;
    [SerializeField] private int _countMultiply;
    [SerializeField] private HouseBlueprint building;
    


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
        }

        
    }

    public void SetRandomDark()
    {
        _indexOfNode.x = Random.Range(0, 29);
        _indexOfNode.y = Random.Range(0, 29);
        _infectedTile = _house.m_Tiles[_indexOfNode.x, _indexOfNode.y].TakeNode();
        AddSquareEffect(_infectedTile, _countMultiply);
    }

    public void DestroyHouse()
    {
        _indexOfNode.x = Random.Range(0, 29);
        _indexOfNode.y = Random.Range(0, 29);
        _infectedTile = _house.m_Tiles[_indexOfNode.x, _indexOfNode.y].TakeNode();
        _infectedTile.DisableEffect();
        
        AddSquareEffect(_infectedTile, _countMultiply);
        _infectedTile.Destroying(); 
    }

    private void AddSquareEffect(Node startPoint, int countMultiply) //countMultiply = количество слоев квадрата
    {
        
        for (int i = startPoint.GetNodeIndex().x - countMultiply; i <= startPoint.GetNodeIndex().x + countMultiply; i++)
        {
            if (i < 0 || i > _house.dimensions.x - 1)
                continue;

            for (int j = startPoint.GetNodeIndex().y - countMultiply; j <= startPoint.GetNodeIndex().y + countMultiply; j++)
            {
                if (j < 0 || j > _house.dimensions.y - 1)
                    continue;

                var _node = _house.m_Tiles[i, j].TakeNode();
                _node.Infected();
            }
        }
    }


}
