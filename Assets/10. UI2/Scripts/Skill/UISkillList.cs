
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillList : MonoBehaviour
{
    public Transform content;
    public UISkillElement skillElementPrefab;

    public void Initalized()
    {
        foreach (UISkillData data in SkillManager.Instance.skillDataList)
        {
            Instantiate(skillElementPrefab, content).SetData(data);
        }
    }
}
