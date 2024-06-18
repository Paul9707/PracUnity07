using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotnetDelegateTest : MonoBehaviour
{
    // Action ��������Ʈ: 
    // �⺻���� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����
    // ��ȯ���� ���� �޼��带 ������ �� �ִ� ��������Ʈ
    Action action;

    // Action ��������Ʈ�� ���׸� Ÿ���� �Ķ���� Ÿ���� �������ִ� ���̴�. 
    // ���� ���׸����� �������� Ÿ�Կ� ��������Ʈ�� �����ϴ� ���� �����ϴ�.
    // ���׸��� ������ �� 16������ �����ϴ�.
    Action<int> actionWithIntParam;
    Action<float, float> actionWithTwoFloatParam;


    // Func ��������Ʈ:
    // ��ȯ���� �ִ� ������ ��������Ʈ�� Dotnet���� �⺻������ �����Ͽ� ����
    Func<object> func;

    // Func ��������Ʈ�� ���׸� Ÿ�� �� �� �� ��ȯ��, ���� �Ķ���� Ÿ�� ����
    Func<string, int> parseFunc;

    // Predicate ��������Ʈ:
    // ��ȯ���� bool�̰�, 1�� �̻��� �Ķ���Ͱ� �ִ� ������ ��������Ʈ
    Predicate<object> predicate;

    // Func<float, bool> �� ���� ������ 

    private void Start()
    {
        action = SomeAction;
        actionWithIntParam = SomeActionWithPram;
        parseFunc = Parse;



        // Predicate ��� ����
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(8);
        intList.Add(9);
        intList.Add(10);

        // int ����Ʈ���� ¦���� �̾Ƴ��� ���
        List<int> evenList = intList.FindAll(IsEven);

        foreach (int i in evenList)
        {
            print(i);
        }

        // predicate�� ���, �Ϻ� �÷��� �Լ��� ���� �Ǵ��� ���� ���Ǹ�
        // Bool�� �����ϴ� �Լ��� ���·� �ޱ� ���� Ȱ���.

        // ¦���� FindAll �Ҷ� ���� �޼��带 ����� ��� 
        // ������ �����Ҷ� �ѹ��� �����;� �ϴ� ��� �̷��� ����ϸ� �޸𸮸� �Ƴ� �� �ִ�.
        List<int> evenListByAnonymousMethod = intList.FindAll
            (
            delegate (int param)
            {
                return param % 2 == 0;
            }
            );
    }

    private void SomeAction() { }
    private void SomeActionWithPram(int a)
    {
        // a�� ���𰡸� �Ѵٰ� ġ�� 
    }

    private int Parse(string str)
    {
        return int.Parse(str);
    }

    private bool IsEven(int param)
    {
        return param % 2 == 0;
    }
}
