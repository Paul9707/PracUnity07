using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
    //currency element가 생성되어 content의 자식 객체로 만들어야 함.
    public Transform content; // Scroll view List 내부 Transform
    public UIcurrencyElement currencyElementPrefab; // element UI 요소 프리팹으로 참조하여 생성

 

    public void Initalized()
    {
       
        foreach (CurrencyData data in DataManger.Instance.currencyDataList)
        {
            Instantiate(currencyElementPrefab, content).SetData(data); // CurrencyElement를 생성 
        }
    }
}
