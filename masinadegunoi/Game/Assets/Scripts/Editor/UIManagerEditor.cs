using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UIManager))]
public class UIManagerEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
	
		UIManager manager = (UIManager)target;

		if (GUILayout.Button ("Add Trigger Button")) 
		{
			manager.AddTriggerButton();
		}

		if (GUILayout.Button ("Add Select Button")) 
		{
			manager.AddSelectButton();
		}

		if (GUILayout.Button ("Add Composed Button")) 
		{
			manager.AddComposedButton();
		}
	}
}
