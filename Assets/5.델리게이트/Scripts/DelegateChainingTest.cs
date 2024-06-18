using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChainingTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        // 델리게이트 인스턴스 생성, MessageTrim 메서드를 할당
        otherDelegate = MessageTrim; 
        // 델리게이트 체인에 MessageAllTrim 메서드를 추가
        otherDelegate += MessageAllTrim;
        // 델리게이트 체인에 MessageDuplicate 메서드를 추가
        otherDelegate += MessageDuplicate;
        // 델리게이트 체인에 MessageLower 메서드를 추가
        otherDelegate += MessageLower;

        // 델리게이트 체인에서 MessageAllTrim 메서드 제거
        otherDelegate -= MessageAllTrim;

        otherDelegate?.Invoke(" Hello World ");

        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;

        // 더하기 연산자를 사용하지 않고 대입할 경우 위에 넣었던건 다 무시되고 이것만 실행된다.
        //otherDelegate = MessageTrim;

        // 빼기에 경우 가장 최근에 넣었던 메서드가 빠진다. -> 스택과 비슷한 구조인데 스택은 종류에 상관없이 맨마지막 메서드를 빼지만 델리게이트는 특정 메서드의 제일 마지막을 빼는 것이다.
        otherDelegate -= MessageDuplicate; 
        otherDelegate?.Invoke(" Hello World ");
    }

    private void MessageTrim(string message)
    {
        // string.Trim() : 문자열에서 앞 뒤 공백을 제거하여 반환한다.
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        // string.Replace() : 내부의 공백을 모두 지우려면 Replace()를 사용한다.저 두가지 케이스를 다 지우는 것
        print(message.Replace(" ", ""));
    }
    private void MessageDuplicate(string message)
    {
        print(message + message);
    }
    private void MessageLower(string message)
    {
        //string.ToLower() : 문자열을 소문자로 변환하여 반환한다.
       print(message.ToLower());
    }


}
