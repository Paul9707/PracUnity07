using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // print(someEnum.Current); 맨처음은 null이다.
    // IEnumerator 안에 있는 데이터가 순차적으로 나올수 있는 것들 

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

        
        //한칸씩 내려가면서 출력
        //foreach (Transform child in transform)
        //{
        //    print(child.name);
        
        //}

        //IEnumerator thisIsCoroutine = ThisIsCoroutine();
        //thisIsCoroutine.MoveNext();
        //print("코루틴 한싸이클 넘겼다");

        //StartCoroutine(thisIsCoroutine);

        //StartCoroutine(SecondCoroutine(10, 0.5f));
        //StartCoroutine(RealtimeSecondsCoroutine(10, 0.5f));

        StartCoroutine(UntileCoroutine());
    }

    private IEnumerator SomeCoroutine()
    {

        yield return "하이";

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
        print("코루틴 시작");
        yield return new WaitForSeconds(1f); // MoveNext()가 호출 되면 여기서 대기한다.
        print("1초가 지났다");
        yield return new WaitForSeconds(3f);
        print("3초 더 지났다");
        yield return new WaitForSeconds(4f);
        print("4초 더 지났다");
    }

    private IEnumerator SecondCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for (int i = 0; i < count; i++)
        {

           print($"{i}번 호출 {timeTemp} 초 지남");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator RealtimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for (int i = 0; i < count; i++)
        {

            print($"{i}번 호출 {timeTemp} 초 지남");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;
    private IEnumerator UntileCoroutine() // 버프효과를 줄때 사용가능할듯?
    {
 
        yield return new WaitUntil(() => { return continueKey; }); // WaitUntil: continueKey가 true가 될때까지 대기 -> true가 되면 다음으로 넘어감 
        print("컨티뉴 키가 True가 됨");
        yield return new WaitWhile(() => { return continueKey; }); // WaitWhile: continueKey가 false가 될때까지 대기 -> false가 되면 다음으로 넘어감
        print("컨티뉴 키가 False가 됨");
    }

 
}
