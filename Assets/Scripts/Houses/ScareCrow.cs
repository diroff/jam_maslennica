using UnityEngine;

public class ScareCrow : HouseBlueprint
{
    [SerializeField] private int _countOfZones;

    public override void MakeEffect()
    {
        AddSpecaialZone(Node, _countOfZones);
    }

    private void AddSpecaialZone(Node startPoint, int countBlock) //countBlock = количество слоев вправо
    {
        int currentLayer = -2;

        for (int i = startPoint.GetNodeIndex().x + 1; i <= startPoint.GetNodeIndex().x + countBlock; i++)
        {
            if (i < 0 || i > Node.BuildManager.Area.dimensions.x - 1)
                continue;

            for (int j = startPoint.GetNodeIndex().y - (currentLayer + 2); j <= startPoint.GetNodeIndex().y + (currentLayer + 2); j++)
            {
                if (j < 0 || j > Node.BuildManager.Area.dimensions.y - 1)
                    continue;

                Node.BuildManager.Area.m_Tiles[i, j].TakeNode().AddAbility(1);
            }

            currentLayer++;
        }
    }
}