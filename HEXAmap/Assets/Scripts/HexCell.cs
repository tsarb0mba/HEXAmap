using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
	public HexCoordinates coordinates;
	public Color color;

	[SerializeField]
	HexCell[] neighbors;

	public HexCell GetNeighbor(HexDirection direction){
		return neighbors[(int)direction];
	}

	//cell a의 w가 b면,b의 e가 a라고 동시에 설정해줌.
	public void SetNeighbor(HexDirection direction, HexCell cell){
		neighbors[(int)direction] = cell;
		cell.neighbors[(int)direction.Opposite()]=this;
	}
}

/**
 * public enum HexDirection{
 * 	NE,E,SE,SW,W,NW
 * }
 */