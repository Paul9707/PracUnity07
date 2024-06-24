using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// 플레이어 데이터를 참조하는 클래스
public class UIPlayerData
{
    public int[] currencyArray = 
        // Enum.GetValues: 열거형 타입 내의 요소 전부를 가져오는 함수
        new int[Enum.GetValues(typeof (CurrencyType)).Length];

    public int this[CurrencyType type]
    {
        get { return currencyArray[(int)type]; }
        set { currencyArray[(int)type] = value; }
    }


}



public class DataManger : MonoBehaviour
{
    public List<CurrencyData> currencyDataList;
    public UICurrencyList uiCurrencyList;
    public static DataManger Instance { get; private set; }


    public UIPlayerData playerData = new UIPlayerData();

    public Action<CurrencyType, int> onCurrencyAmountChange; // delegate 선언

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        uiCurrencyList.Initalized();
    }

    public void AddCurrency(int param)
    {
        CurrencyType type = (CurrencyType)param;
        playerData[type]++;

        onCurrencyAmountChange?.Invoke(type, playerData[type]);

        print($"{type} 상승: {playerData[type]}");
    }
}
