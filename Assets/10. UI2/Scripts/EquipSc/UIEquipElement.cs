using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipElement : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI countText;

    private EquipData data;

    public void SetData(EquipData data)
    {
        this.data = data;

        iconImage.sprite = data.IconSprite;
        nameText.text = $"�̸�: {data.equipName}";
        countText.text = $"����: {data.maxCount.ToString()}";

    }

  

}
