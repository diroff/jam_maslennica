using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    [SerializeField] private HousePlacementArea _house;
    [SerializeField] private Vector2Int _indexOfNode;
    [SerializeField] private PlacementTile[,] _tile;
    [SerializeField] private Node _infectedTile;
    [SerializeField] private int _countMultiply;
    


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
        _indexOfNode.x = Random.Range(0, _indexOfNode.x + 1);
        _indexOfNode.y = Random.Range(0, _indexOfNode.y + 1);
        _infectedTile = _house.m_Tiles[_indexOfNode.x, _indexOfNode.y].TakeNode();
        AddSquareEffect(_infectedTile, _countMultiply);
    }


    private void AddSquareEffect(Node startPoint, int countMultiply) //countMultiply = ���������� ����� ��������
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
