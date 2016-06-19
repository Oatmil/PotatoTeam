using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(CameraScript))]
public class CameraEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraScript myScript = (CameraScript)target;
        if (GUILayout.Button("SetPosition"))
        {
            myScript.SetCameraPosition();
        }

        if (GUILayout.Button("Go To Position"))
        {
            myScript.GotoPosition();
        }
    }
}
#endif

