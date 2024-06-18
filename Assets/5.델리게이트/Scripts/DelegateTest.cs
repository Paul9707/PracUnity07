using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// Delegate (대리자)
// C++의 함수 포인터와 유사한 기능
// 메서드를 변수처럼 가변적으로 활용 할 수 있는 기능 

// Delegate 정의 -> 일종의 (레퍼런스)자료형 처럼 형식을 지정하도록 선언해야 한다.

//[접근지정자] delegate [반환형식] [이름]    ([매개변수]);
// 델리게이트 선언의 위치는 class, enum등과 동일
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
        otherDelegate = print; // 오브젝트는 스트링보다 큰 경우이기 때문에 매개변수가 서로 호환이 될 경우 사용가능하다. (암시적 캐스팅이 가능)

        // Delegate도 인스턴스를 참조하는 형식으로 생성된다.
        otherDelegate = null; // null로 초기화 가능
        otherDelegate = new OtherDelegateMethod(PrintMessage); // 정확한 초기화는 이런 방식 -> 암시적으로 초기화 되어 바로 적용가능
        //otherDelegate("");
        otherDelegate ?. Invoke(""); // 위에 방식과 같다. -> ?.Invoke()는 null이 아닐 경우에만 실행된다.
        // if(otherDelegate != null) otherDelegate(""); ㄴ 위에 방식과 같다.
    }

    public void CalcChange(int i) // 런타임에서도 함수가 가변적으로 변할 수 있다.
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
