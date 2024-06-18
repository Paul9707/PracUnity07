using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class AnnoymousMethodTest : MonoBehaviour
{


    /* 무명메서드란 
      
        - 클래스 안에서 정의하는 것이 아닌 메서드 내에서 정의되는 메서드
        - 메서드에 이름이 없으며, Delegate에 할당하기 위해서는
          ㄴ 해당 Delegate와 매개변수와 반환형의 타입이 일치해야 함.
     
    - 장점
        ㄴ 1회성으로 사용되는 함수의 정의를 따로 함수 밖에서 할 필요가 없어 가독성이 증가하는 측면이 있다.
        ㄴ 또한, 지역적으로 사용되는 델리게이트 변수에 할당하는 식으로 사용되는 경우 
           해당 포커스가 종료되면 메모리 할당을 해제 하므로 불필요하게 함수가 메모리를 점유하는 것을 방지 할 수 있다.
    
    - 단점
        ㄴ 델리게이트 체이닝을 사용할 때 , 해당 메서드만 체인에서 제거하는것이 불가능하다. -> 이름이 없기 때문에 특정할 수 가 없음
        ㄴ 또한, 한 메서드에서 많은 무명메서드 정의 시 오히려 가독성이 떨어질 수 있다. -> 무슨 로직인지 일일히 다 확인해야 한다.

      람다식: 무명메서드의 축약식 표현 -> c#한정 무명메서드랑 같다.

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

        // 무명 메서드 할당에서 매개변수 참조가 불필요할 경우 생략이 가능하다. -> 파라미터의 내용을 안쓰는 경우 생략가능
        autoCastPlus += delegate    
        {
            print("Calc Finished");
        };
        someFunc = delegate (int a)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("입력된 파라미터는");
            sb.Append(a);
            sb.Append("입니다.");

            return sb.ToString();
        };

        // 람다식으로 표현
        someAction += (/*파라미터*/) => {/*함수 본문*/ };

        // delegate 키워드 대신 => 기호를 통해 무명메서드 임을 명시
        someFunc += (int a) => { return a + "is intager"; };
        
        // 파라미터의 자료형 + 소괄호 생략 가능 -> 자료형을 추론할 수 있기 때문에 / return문이 한줄일 경우 중괄호 생략 가능
        someFunc += a =>  a + "is intager.";
        
        // 파라미터가 2개 일때 소괄호를 생략 불가능
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
