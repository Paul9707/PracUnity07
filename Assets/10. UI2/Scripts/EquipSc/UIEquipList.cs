using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEquipList : MonoBehaviour
{
    public Transform content;
    public UIEquipElement equipElementPrefab;
    

    public void Initalized()
    {
        foreach (EquipData data in EquipManager.Instance.equipDataList)
        {
            Instantiate(equipElementPrefab, content).SetData(data);
        }
    }
}
