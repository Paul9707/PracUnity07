using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Weapon,
    Armor,
    Accessory
}

[CreateAssetMenu(fileName = "EquipData", menuName = "Scriptable Object/Equipdata", order = 0)]
public class EquipData : ScriptableObject
{
    public string equipName;
    public Sprite IconSprite;
    public EquipType equipType;
    public int maxCount;
}
