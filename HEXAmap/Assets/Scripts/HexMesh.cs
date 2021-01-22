using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour {
	Mesh hexMesh;
 	List<Vector3> vertices;
 	List<int> triangles;
 	MeshCollider meshCollider;
 	List<Color> colors;
 	
 	void Awake () {
		GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
		meshCollider = gameObject.AddComponent<MeshCollider>();
		hexMesh.name = "Hex Mesh";
		vertices = new List<Vector3>();
		colors = new List<Color>();
		triangles = new List<int>();
	}

	public void Triangulate (HexCell[] cells){
		hexMesh.Clear();
		vertices.Clear();
		triangles.Clear();
		colors.Clear();

		for(int i=0; i<cells.Length; i++){
			Triangulate(cells[i]);
		}

		hexMesh.vertices = vertices.ToArray();
		hexMesh.triangles = triangles.ToArray();
		hexMesh.colors = colors.ToArray();
		hexMesh.RecalculateNormals();
		meshCollider.sharedMesh = hexMesh;
	}

	void Triangulate(HexCell cell){
		for(HexDirection d = HexDirection.NE;d<=HexDirection.NW; d++){
			Triangulate(d,cell);
		}
	}

	void Triangulate(HexDirection direction, HexCell cell){
		Vector3 center = cell.transform.localPosition;
		AddTriangle(
			center,
			center + HexMetrics.GetFirstCorner(direction),
			center + HexMetrics.GetSecondCorner(direction)
		);
		HexCell prevNeighbor = cell.GetNeighbor(direction.Previous()) ?? cell;	
		HexCell neighbor = cell.GetNeighbor(direction) ?? cell; // cause some cell don't have neighbor
		HexCell nextNeighbor = cell.GetNeighbor(direction.Next()) ?? cell;
		AddTriangleColor(
			cell.color,
			(cell.color + prevNeighbor.color + neighbor.color) / 3f,
			(cell.color + neighbor.color + nextNeighbor.color) / 3f
		);	
	}


	void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3){
		int vertexIndex = vertices.Count;
		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		triangles.Add(vertexIndex);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 2);
	}

	void AddTriangleColor(Color cr1, Color cr2, Color cr3){
		colors.Add(cr1);
		colors.Add(cr2);
		colors.Add(cr3);
	}
}