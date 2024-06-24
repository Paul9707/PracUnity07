using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
    //currency element�� �����Ǿ� content�� �ڽ� ��ü�� ������ ��.
    public Transform content; // Scroll view List ���� Transform
    public UIcurrencyElement currencyElementPrefab; // element UI ��� ���������� �����Ͽ� ����

 

    public void Initalized()
    {
       
        foreach (CurrencyData data in DataManger.Instance.currencyDataList)
        {
            Instantiate(currencyElementPrefab, content).SetData(data); // CurrencyElement�� ���� 
        }
    }
}
