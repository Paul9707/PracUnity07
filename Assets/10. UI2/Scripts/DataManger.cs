using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// �÷��̾� �����͸� �����ϴ� Ŭ����
public class UIPlayerData
{
    public int[] currencyArray = 
        // Enum.GetValues: ������ Ÿ�� ���� ��� ���θ� �������� �Լ�
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

    public Action<CurrencyType, int> onCurrencyAmountChange; // delegate ����

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

        print($"{type} ���: {playerData[type]}");
    }
}
