using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SelectButton))]
public class SelectButtonEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
	}
}
