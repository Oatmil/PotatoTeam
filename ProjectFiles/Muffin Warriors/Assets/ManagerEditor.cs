using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(RoundManager))]
public class ManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RoundManager myManager = (RoundManager)target;
        if (GUILayout.Button("Preview Environment"))
        {
            myManager.PreviewEnvironment();
        }
        if(GUILayout.Button("Save Environment Lights"))
        {
            myManager.SaveEnvironment();
        }
    }
	
}
#endif