using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
	const float movementMin = 0.01f;
	public override void OnInspectorGUI()
	{
		Player player = (Player)target;
		DrawDefaultInspector ();
		player.MoveKey = EditorGUILayout.TextField ("Horizontal key", player.MoveKey);
		player.MovementSpeedFactor = EditorGUILayout.FloatField ("Speed Factor", player.MovementSpeedFactor);

		if (player.MovementSpeedFactor < movementMin)
			player.MovementSpeedFactor = movementMin;

	}



}

