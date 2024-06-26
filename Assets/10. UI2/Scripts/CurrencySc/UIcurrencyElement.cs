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
        //currency element �� �����ǰ� ���� ȣ�� �� �ʱ�ȭ �Լ�

        iconImage.sprite = data.IconSprite; // ������ ��ü
        nameText.text = data.currencyName; // �̸� ����

        // �����
        // �ּ�/ �ִ밪 �Ҵ� 
        progressBar.minValue = 0;
        progressBar.maxValue = data.maxCount;

        int currentCount = DataManger.Instance.playerData[data.currencyType];

        // ����� �ؽ�Ʈ ���� 
        progressText.text = $"{currentCount} / {data.maxCount.ToString()}";

        progressBar.value = currentCount;
        // ��ȭ ���� ���� �ɶ� ȣ��ǵ��� delegate stack�� �߰�
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
