using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// Delegate (�븮��)
// C++�� �Լ� �����Ϳ� ������ ���
// �޼��带 ����ó�� ���������� Ȱ�� �� �� �ִ� ��� 

// Delegate ���� -> ������ (���۷���)�ڷ��� ó�� ������ �����ϵ��� �����ؾ� �Ѵ�.

//[����������] delegate [��ȯ����] [�̸�]    ([�Ű�����]);
// ��������Ʈ ������ ��ġ�� class, enum��� ����
public delegate float SomDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string message);

public class DelegateTest : MonoBehaviour
{

    public float x;
    public float y;
    public SomDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    private void Start()
    {
        //someDelegate = Add;
        //someDelegate = Minus;
        //someDelegate = Multiple;
        //someDelegate = Divide;

        otherDelegate = PrintMessage;
        otherDelegate = print; // ������Ʈ�� ��Ʈ������ ū ����̱� ������ �Ű������� ���� ȣȯ�� �� ��� ��밡���ϴ�. (�Ͻ��� ĳ������ ����)

        // Delegate�� �ν��Ͻ��� �����ϴ� �������� �����ȴ�.
        otherDelegate = null; // null�� �ʱ�ȭ ����
        otherDelegate = new OtherDelegateMethod(PrintMessage); // ��Ȯ�� �ʱ�ȭ�� �̷� ��� -> �Ͻ������� �ʱ�ȭ �Ǿ� �ٷ� ���밡��
        //otherDelegate("");
        otherDelegate ?. Invoke(""); // ���� ��İ� ����. -> ?.Invoke()�� null�� �ƴ� ��쿡�� ����ȴ�.
        // if(otherDelegate != null) otherDelegate(""); �� ���� ��İ� ����.
    }

    public void CalcChange(int i) // ��Ÿ�ӿ����� �Լ��� ���������� ���� �� �ִ�.
    {
        switch (i) 
        {
            case 0:
                someDelegate = Add;
                break;
            case 1: 
                someDelegate = Minus;
                break;
            case 2:
                someDelegate = Multiple;
                break;
            case 3:
                someDelegate = Divide;
                break;
        }
    }

    public void ButtoncClick()
    {
        print(someDelegate?.Invoke(x, y));
    }

    public float Add(float x, float y) { return x + y; }

    public float Minus(float x, float y) { return x - y; }

    public float Multiple(float a, float b) { return a * b; }
   
    public float Divide(float a, float b) { return a / b; }

    public void PrintMessage(string message)
    {
      
    }
}
