using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FileTest))] // FileTset 스크립트를 기반으로 한 에디터
public class FileTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FileTest fileTest = target as FileTest;

        if (GUILayout.Button("Save"))
        {
            Debug.Log("Save");
            fileTest.Save();
        }

        if (GUILayout.Button("Load"))
        {
            Debug.Log("Load");  
            fileTest.Load();
        }
    }
}
