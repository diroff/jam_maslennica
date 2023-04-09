using UnityEngine;

public enum PlacementTileState
{
	Filled,
	Empty,
	Buffed,
	Infected
}

public class PlacementTile : MonoBehaviour
{
	public Material emptyMaterial;
	public Material filledMaterial;
	public Material buffedMaterial;
	public Material infectedMaterial;
	public Renderer tileRenderer;
	[HideInInspector]
	public Vector2Int TileIndex;
	private void Start()
	{
		tileRenderer = GetComponent<MeshRenderer>();
	}
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

			case PlacementTileState.Buffed:
				if (tileRenderer != null & buffedMaterial != null)
					tileRenderer.sharedMaterial = buffedMaterial;

				break;
			case PlacementTileState.Infected:
				if (tileRenderer != null & infectedMaterial != null)
					tileRenderer.sharedMaterial = infectedMaterial;
				break;
		}
	}

	public Node TakeNode()
	{
		return GetComponent<Node>();
	}
}