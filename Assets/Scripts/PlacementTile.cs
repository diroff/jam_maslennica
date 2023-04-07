using System.Collections.Generic;
using UnityEngine;

public enum PlacementTileState
{
	Filled,
	Empty,
}

public class PlacementTile : MonoBehaviour
{
	public Material emptyMaterial;
	public Material filledMaterial;
	public Renderer tileRenderer;

	[HideInInspector]
	public Vector2Int TileIndex;

	public void SetState(PlacementTileState newState)
	{
		switch (newState)
		{
			case PlacementTileState.Filled:
				if (tileRenderer != null && filledMaterial != null)
					tileRenderer.sharedMaterial = filledMaterial;

				break;

			case PlacementTileState.Empty:
				if (tileRenderer != null && emptyMaterial != null)
					tileRenderer.sharedMaterial = emptyMaterial;

				break;
        }
	}

	public Node TakeNode()
	{
		return GetComponent<Node>();
	}
}