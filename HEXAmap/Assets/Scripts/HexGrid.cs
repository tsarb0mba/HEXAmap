using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;

	HexCell[] cells;

    // Start is called before the first frame update
    void Awake ()
    {
		cells = new HexCell[height*width];

		int x,z,i; // y is always 0
		for(;z<height;z++){
			for(;x<width;x++)
				CreateCell(x,z,i++);
		}
    }

    void CreateCell(int x, int z, int i){
    	Vector3 position;
    	position.x = x*10f;
    	position.y = 0f;
    	position.z = z*10f;

    	HexCell cell  =cells[i] = Instantiate<HexCell>(cellPrefab);
    	cell.transform.SetParent(transform,false);
    	cell.transform.localPosition = position;
    }
}
