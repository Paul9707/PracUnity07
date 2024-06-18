using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    /* 유니티 이벤트 (UnityEvent)
        
     - 유니티 Inspector 에서 델리게이트와 같이 특정 함수를 등록하여 호출 할 수 있도록 만들어진 클래스 
     
     */
    public UnityEvent someEvent;
    public UnityEvent<float> onHPChange;
    public UnityEvent<string> onHPChangeString;
    private float maxHP = 100;
    private float currentHP = 100;
    private float hpCache = 100;
    public void SomeMethod()
    {
        print("Some Event Called");
    }
   
    private void Start()
    {
        onHPChange.AddListener(PrintCurrentHP);

    }
    public void PrintCurrentHP(float value)
    {
        print($"currnet HP Amount is : {value}");
    }
    public void OnValueChanged(float value)
    {
        print(value);
    }

    public void OnPositionChanged(Vector2 value)
    {
        transform.position = value;
    }

    public void OnDamagedButton()
    {
        currentHP -= 10;
        print(currentHP);
    }
    private void Update()
    {
        if (hpCache != currentHP)
        {
            // hp값이 바뀌었다면
            onHPChange?.Invoke(currentHP/maxHP);
            onHPChangeString?.Invoke((currentHP / maxHP).ToString("p1"));
            hpCache = currentHP;
        }
    }


}
