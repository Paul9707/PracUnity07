using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Attack,
    Attack2,
    Attack3
   
}

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Object/Skilldata", order = 0)]
public class UISkillData : ScriptableObject
{
    public string skillName;
    public Sprite IconSprite;
    public SkillType skillType;
    public int maxCount;
}
