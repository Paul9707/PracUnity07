using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkilldata
{
    public int[] skillArray = new int[Enum.GetValues(typeof(SkillType)).Length];

    public int this[SkillType type]
    {
        get { return skillArray[(int)type]; }
        set { skillArray[(int)type] = value; }
    }
}


public class SkillManager : MonoBehaviour
{
    public List<UISkillData> skillDataList;
    public UISkillList SkillList;
    public static SkillManager Instance { get; private set; }

    public UISkilldata skillData = new UISkilldata();
    public Action<SkillType, int> onSkillAmountChange;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SkillList.Initalized();
    }
    public void AddSkillCount(int param)
    {
        SkillType type = (SkillType)param;

        skillData[type]++;

        onSkillAmountChange?.Invoke(type, skillData[type]);
    }
}