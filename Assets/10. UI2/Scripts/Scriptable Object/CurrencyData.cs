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

// 함수 또는 생성자 호출시 [파라미터 이름] = [값] 형태로 파라미터 순서에 상관없이 전달 가능
[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Object/Currencydata", order =0)]
public class CurrencyData : ScriptableObject
{
   
   
    //재화 데이터를 구조화 한 Scriptable Object
    public string currencyName;
    public Sprite IconSprite;
    public CurrencyType currencyType; // json 파일로 패싱할 경우 int로 변환해야 함 
    public int maxCount;


}
