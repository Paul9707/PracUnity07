using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    /* ����Ƽ �̺�Ʈ (UnityEvent)
        
     - ����Ƽ Inspector ���� ��������Ʈ�� ���� Ư�� �Լ��� ����Ͽ� ȣ�� �� �� �ֵ��� ������� Ŭ���� 
     
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
            // hp���� �ٲ���ٸ�
            onHPChange?.Invoke(currentHP/maxHP);
            onHPChangeString?.Invoke((currentHP / maxHP).ToString("p1"));
            hpCache = currentHP;
        }
    }


}
