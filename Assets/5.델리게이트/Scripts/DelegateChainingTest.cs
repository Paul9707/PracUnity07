using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChainingTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        // ��������Ʈ �ν��Ͻ� ����, MessageTrim �޼��带 �Ҵ�
        otherDelegate = MessageTrim; 
        // ��������Ʈ ü�ο� MessageAllTrim �޼��带 �߰�
        otherDelegate += MessageAllTrim;
        // ��������Ʈ ü�ο� MessageDuplicate �޼��带 �߰�
        otherDelegate += MessageDuplicate;
        // ��������Ʈ ü�ο� MessageLower �޼��带 �߰�
        otherDelegate += MessageLower;

        // ��������Ʈ ü�ο��� MessageAllTrim �޼��� ����
        otherDelegate -= MessageAllTrim;

        otherDelegate?.Invoke(" Hello World ");

        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;
        otherDelegate += MessageDuplicate;

        // ���ϱ� �����ڸ� ������� �ʰ� ������ ��� ���� �־����� �� ���õǰ� �̰͸� ����ȴ�.
        //otherDelegate = MessageTrim;

        // ���⿡ ��� ���� �ֱٿ� �־��� �޼��尡 ������. -> ���ð� ����� �����ε� ������ ������ ������� �Ǹ����� �޼��带 ������ ��������Ʈ�� Ư�� �޼����� ���� �������� ���� ���̴�.
        otherDelegate -= MessageDuplicate; 
        otherDelegate?.Invoke(" Hello World ");
    }

    private void MessageTrim(string message)
    {
        // string.Trim() : ���ڿ����� �� �� ������ �����Ͽ� ��ȯ�Ѵ�.
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        // string.Replace() : ������ ������ ��� ������� Replace()�� ����Ѵ�.�� �ΰ��� ���̽��� �� ����� ��
        print(message.Replace(" ", ""));
    }
    private void MessageDuplicate(string message)
    {
        print(message + message);
    }
    private void MessageLower(string message)
    {
        //string.ToLower() : ���ڿ��� �ҹ��ڷ� ��ȯ�Ͽ� ��ȯ�Ѵ�.
       print(message.ToLower());
    }


}
