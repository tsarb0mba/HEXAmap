using UnityEngine;

public static class HexMetrics {

	public const float outerRadius = 10f;
	public const float innerRadius = outerRadius * 0.866025404f;

	//used to blend ragions
	public const float solidFactor = 0.75f;
	public const float blendFactor = 1f - solidFactor;

	static Vector3[] corners = {
		new Vector3(0f,0f,outerRadius),
		new Vector3(innerRadius,0f,0.5f*outerRadius),
		new Vector3(innerRadius,0f,-0.5f*outerRadius),
		new Vector3(0f, 0f, -outerRadius),
		new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
		new Vector3(0f, 0f, outerRadius)
	};

	public static Vector3 GetFirstCorner(HexDirection direction){
		return corners[(int)direction];
	}

	public static Vector3 GetSecondCorner(HexDirection direction){
		return corners[(int)direction+1];
	}

	public static Vector3 GetFirestSolidCorner(HexDirection direction){
		return corners[(int)direction]*solidFactor;
	}

	public static Vector3 GetSecondSolidCorner(HexDirection direction){
		return corners[(int)direction+1]*solidFactor;
	}

}