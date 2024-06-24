using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
    Coin,
    Crystal,
    Food,
    Metal,
    Wood 
}

// �Լ� �Ǵ� ������ ȣ��� [�Ķ���� �̸�] = [��] ���·� �Ķ���� ������ ������� ���� ����
[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Object/Currencydata", order =0)]
public class CurrencyData : ScriptableObject
{
   
   
    //��ȭ �����͸� ����ȭ �� Scriptable Object
    public string currencyName;
    public Sprite IconSprite;
    public CurrencyType currencyType; // json ���Ϸ� �н��� ��� int�� ��ȯ�ؾ� �� 
    public int maxCount;


}
