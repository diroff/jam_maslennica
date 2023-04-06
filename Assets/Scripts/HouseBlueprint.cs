using System.Collections;
using UnityEngine;

[System.Serializable]

public class HouseBlueprint : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _cost;

    private Node _placementNode;
    public Node PlacementNode => _placementNode;

    public int Cost => _cost;

    public void SetNode(Node node)
    {
        _placementNode = node;
    }

    public virtual void MakeEffect()
    {

    }
}
