using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   

public class UISkillElement : MonoBehaviour
{
    public Image iconImange;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillLevel;

    private UISkillData data;

    public void SetData(UISkillData data)
    {
        this.data = data;

        iconImange.sprite = data.IconSprite;
        skillName.text = data.skillName;

        int currentLevel = SkillManager.Instance.skillData[(data.skillType)];
        skillLevel.text = $"{currentLevel}";
        
        SkillManager.Instance.onSkillAmountChange += OnSkillAmountChange;
    }

    public void OnSkillAmountChange(SkillType type, int level)
    {
        if (type == data.skillType)
        {
            skillLevel.text = $"{level}";
        }
    }
  
}
