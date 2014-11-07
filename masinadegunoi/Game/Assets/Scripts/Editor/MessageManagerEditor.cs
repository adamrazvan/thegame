using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MessageManager))]
public class MessageManagerEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		
	}
}

