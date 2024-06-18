using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemDictionary))]
public class ItemEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ItemDictionary itemDictionary = target as ItemDictionary;

        if (GUILayout.Button("Save"))
        {
            itemDictionary.Save();
        }

    }

}
