using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{

    public static DayNightManager instance { get; private set; }

    public Transform lightTransform; // Directional Light 오브젝트 참조

    private bool isDay = true; // 낮이면 ture 밤이면 false

    // observer pattern을 부분적으로 구현 
    public Action<bool> onDayComesUp;
    // 유니티에서 옵저버 패턴 구현시 delegate 또는 eventHandler를 사용할 수 있음

    private void Awake()
    {
        instance = this;
        onDayComesUp = (isDay) =>
        {
            lightTransform.rotation = Quaternion.Euler(isDay ? 30 : 190, 0, 0); // 오일러각을 Quaternion으로 변환
        };
    }
    public void DayToggleButtonClick() // 밤낮 토글 버튼이 호출 
    {
        isDay = !isDay; // isDay 토글 -> 낮이면 밤으로, 밤이면 낮으로 버튼을 누를때 마다 변경
        onDayComesUp?.Invoke(isDay);
        

    }
}
