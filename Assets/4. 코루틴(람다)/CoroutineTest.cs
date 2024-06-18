using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // print(someEnum.Current); ��ó���� null�̴�.
    // IEnumerator �ȿ� �ִ� �����Ͱ� ���������� ���ü� �ִ� �͵� 

    private void Start()
    {
        //IEnumerator someEnum = SomeCoroutine();

        //while (someEnum.MoveNext())
        //{
        //    print(someEnum.Current);
        //}

        //IEnumerator<int> someIntEnum = SomeIntEnumerator();
        //int a = 1000;
        //while (someIntEnum.MoveNext())
        //{
        //    a -= someIntEnum.Current;
        //}

        
        //��ĭ�� �������鼭 ���
        //foreach (Transform child in transform)
        //{
        //    print(child.name);
        
        //}

        //IEnumerator thisIsCoroutine = ThisIsCoroutine();
        //thisIsCoroutine.MoveNext();
        //print("�ڷ�ƾ �ѽ���Ŭ �Ѱ��");

        //StartCoroutine(thisIsCoroutine);

        //StartCoroutine(SecondCoroutine(10, 0.5f));
        //StartCoroutine(RealtimeSecondsCoroutine(10, 0.5f));

        StartCoroutine(UntileCoroutine());
    }

    private IEnumerator SomeCoroutine()
    {

        yield return "����";

        yield return 1;

        yield return false;

        yield return new object();
        
      
    }

    private IEnumerator<int> SomeIntEnumerator()
    {
        yield return 6;
        yield return 3;
        yield return 10;
        yield return 123;
        yield return 777;
    }

    private IEnumerator ThisIsCoroutine()
    {
        print("�ڷ�ƾ ����");
        yield return new WaitForSeconds(1f); // MoveNext()�� ȣ�� �Ǹ� ���⼭ ����Ѵ�.
        print("1�ʰ� ������");
        yield return new WaitForSeconds(3f);
        print("3�� �� ������");
        yield return new WaitForSeconds(4f);
        print("4�� �� ������");
    }

    private IEnumerator SecondCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for (int i = 0; i < count; i++)
        {

           print($"{i}�� ȣ�� {timeTemp} �� ����");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator RealtimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for (int i = 0; i < count; i++)
        {

            print($"{i}�� ȣ�� {timeTemp} �� ����");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;
    private IEnumerator UntileCoroutine() // ����ȿ���� �ٶ� ��밡���ҵ�?
    {
 
        yield return new WaitUntil(() => { return continueKey; }); // WaitUntil: continueKey�� true�� �ɶ����� ��� -> true�� �Ǹ� �������� �Ѿ 
        print("��Ƽ�� Ű�� True�� ��");
        yield return new WaitWhile(() => { return continueKey; }); // WaitWhile: continueKey�� false�� �ɶ����� ��� -> false�� �Ǹ� �������� �Ѿ
        print("��Ƽ�� Ű�� False�� ��");
    }

 
}
