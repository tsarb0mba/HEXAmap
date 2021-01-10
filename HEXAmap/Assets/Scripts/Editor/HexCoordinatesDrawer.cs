using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(HexCoordinates))]
public class HexCoordinatesDrawer : PropertyDrawer
{
	//provided the screen rectangle to draw inside, the serialized data of the property, and the label of the field it belongs to.
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
		HexCoordinates coordinates = new HexCoordinates(
			property.FindPropertyRelative("x").intValue,
			property.FindPropertyRelative("z").intValue
			);
		position = EditorGUI.PrefixLabel(position,label);
		GUI.Label(position,coordinates.ToString());
	}
}
