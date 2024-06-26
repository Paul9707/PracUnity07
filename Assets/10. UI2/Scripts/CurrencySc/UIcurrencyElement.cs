using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
public class UIcurrencyElement : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public Slider progressBar;
    public TextMeshProUGUI progressText;

    private CurrencyData data;

    public void SetData(CurrencyData data)
    {
        this.data = data;
        //currency element 가 생성되고 나서 호출 될 초기화 함수

        iconImage.sprite = data.IconSprite; // 아이콘 교체
        nameText.text = data.currencyName; // 이름 변경

        // 진행바
        // 최소/ 최대값 할당 
        progressBar.minValue = 0;
        progressBar.maxValue = data.maxCount;

        int currentCount = DataManger.Instance.playerData[data.currencyType];

        // 진행바 텍스트 변경 
        progressText.text = $"{currentCount} / {data.maxCount.ToString()}";

        progressBar.value = currentCount;
        // 재화 값이 변경 될때 호출되도록 delegate stack에 추가
        DataManger.Instance.onCurrencyAmountChange += OncurrencyAmountChange;
    }

    public void OncurrencyAmountChange(CurrencyType type, int count)
    {
        if (type == data.currencyType)
        {
            progressBar.value = count;
            progressText.text = $"{count} / {data.maxCount.ToString()}";
        }
    }
}
