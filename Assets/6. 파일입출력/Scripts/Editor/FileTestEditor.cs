using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FileTest))] // FileTset ��ũ��Ʈ�� ������� �� ������
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
