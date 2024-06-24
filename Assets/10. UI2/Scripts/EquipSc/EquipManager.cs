using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEquipData 
{
    public int[] equipArray = new int[Enum.GetValues(typeof(EquipType)).Length];
    public int this[EquipType type]
    {
        get { return equipArray[(int)type]; }
        set { equipArray[(int)type] = value; }
    }
}
public class EquipManager : MonoBehaviour
{
    public List<EquipData> equipDataList;
    public UIEquipList uiEquipList;
    public static EquipManager Instance { get; private set; }

    public UiEquipData equipData = new UiEquipData();

    public Action<EquipType, int> onEquipAmountChange;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        uiEquipList.Initalized();
    }
}
