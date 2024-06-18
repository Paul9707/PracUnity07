using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class AnnoymousMethodTest : MonoBehaviour
{


    /* ����޼���� 
      
        - Ŭ���� �ȿ��� �����ϴ� ���� �ƴ� �޼��� ������ ���ǵǴ� �޼���
        - �޼��忡 �̸��� ������, Delegate�� �Ҵ��ϱ� ���ؼ���
          �� �ش� Delegate�� �Ű������� ��ȯ���� Ÿ���� ��ġ�ؾ� ��.
     
    - ����
        �� 1ȸ������ ���Ǵ� �Լ��� ���Ǹ� ���� �Լ� �ۿ��� �� �ʿ䰡 ���� �������� �����ϴ� ������ �ִ�.
        �� ����, ���������� ���Ǵ� ��������Ʈ ������ �Ҵ��ϴ� ������ ���Ǵ� ��� 
           �ش� ��Ŀ���� ����Ǹ� �޸� �Ҵ��� ���� �ϹǷ� ���ʿ��ϰ� �Լ��� �޸𸮸� �����ϴ� ���� ���� �� �� �ִ�.
    
    - ����
        �� ��������Ʈ ü�̴��� ����� �� , �ش� �޼��常 ü�ο��� �����ϴ°��� �Ұ����ϴ�. -> �̸��� ���� ������ Ư���� �� �� ����
        �� ����, �� �޼��忡�� ���� ����޼��� ���� �� ������ �������� ������ �� �ִ�. -> ���� �������� ������ �� Ȯ���ؾ� �Ѵ�.

      ���ٽ�: ����޼����� ���� ǥ�� -> c#���� ����޼���� ����.

     */
    System.Action someAction;
    System.Action<int, float> autoCastPlus;
    System.Func<int, string> someFunc;
    System.Func<int, int ,string> someFunc2;
    private void Awake()
    {
        someAction = delegate ()
        {
            print("Anonymous Method Called.");
        };


        autoCastPlus = delegate (int a, float b)
        {
            int @return = a + (int)b;
            print(@return);
        };

        // ���� �޼��� �Ҵ翡�� �Ű����� ������ ���ʿ��� ��� ������ �����ϴ�. -> �Ķ������ ������ �Ⱦ��� ��� ��������
        autoCastPlus += delegate    
        {
            print("Calc Finished");
        };
        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("�Էµ� �Ķ���ʹ�");
            sb.Append(a);
            sb.Append("�Դϴ�.");

            return sb.ToString();
        };

        // ���ٽ����� ǥ��
        someAction += (/*�Ķ����*/) => {/*�Լ� ����*/ };

        // delegate Ű���� ��� => ��ȣ�� ���� ����޼��� ���� ���
        someFunc += (int a) => { return a + "is intager"; };
        
        // �Ķ������ �ڷ��� + �Ұ�ȣ ���� ���� -> �ڷ����� �߷��� �� �ֱ� ������ / return���� ������ ��� �߰�ȣ ���� ����
        someFunc += a =>  a + "is intager.";
        
        // �Ķ���Ͱ� 2�� �϶� �Ұ�ȣ�� ���� �Ұ���
        someFunc2 = (a, b) => $"{a} + {b} = {a + b}"; 
    }

    private void Start()
    {
        someAction?.Invoke();
        someAction?.Invoke();
        autoCastPlus?.Invoke(1, 1.1f);
        print(someFunc?.Invoke(3));
    }

    private void SomeAction()
    {

    }

}
