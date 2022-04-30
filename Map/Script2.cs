#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScreenShot))]
public class Script2 : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		ScreenShot t = (ScreenShot)target;
		GUILayout.Label("Сделать снимок карты:", EditorStyles.boldLabel);
		if (GUILayout.Button("Take Screenshot")) t.TakeScreenshot();
	}
}
#endif