using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using UnityEngine;

public class EasyGenricTester : MonoBehaviour
{
    public CubeParent cubeFrom;
    public CubeParent cubeTo;

    private void Awake()
    {
        //cubeFrom�� colors, xPositions, scales �迭�� ���� �����ϰ� ���� 
        cubeTo.colors = ArrayCopy(cubeFrom.colors);
        cubeTo.xPositions = ArrayCopy(cubeFrom.xPositions);
        cubeTo.scales = ArrayCopy<float>(cubeFrom.scales);
    }

    // ���׸��� ����ϸ� �پ��� Ÿ���� �迭�� ������ �� ����
    // Ÿ���� �����Ұ�� �� �ڷ����ۿ� ���� ���� �������� �޼��带 ������ ������ ���׸��� ����� ��� �׷� �ʿ䰡 ����.
    private T[] ArrayCopy<T>(T[] from)
    {
        T[] to = new T[from.Length];

        for (int i = 0; i<from.Length; i++)
        {
            to[i] = from[i]; 

        }

        return to;
    }
}

/*
    - ���׸� �ҿ� 2����

    1. ���׸��� ����Ͽ� ���ǵ� Ŭ������ �ڷ������� ��� �Ǵ� �Լ��� ȣ��    
    ex) List<int> : List��� Ŭ������ ����ϴµ�, �ȿ��� ��޵� �ڷ����� int
    ex) GetComponent<T>() : ���� ������Ʈ�� ������ ������Ʈ�� ã�µ�, TŬ������ ������Ʈ�� ã�´�.

    2. ���� ���׸��� ����� Ŭ���� �Ǵ� �Լ��� ���� 

 
 
 */


public class GenericExample : MonoBehaviour
{
    public List<int> intList = new List<int>();
    public Dictionary<int, int> dictionary = new Dictionary<int, int>();

    private void Start()
    {
        new GameObject().AddComponent<SpriteRenderer>();

        //StructT<Vector3> a;
        //ClassT<GameObject> b;
        //NewT<object> c;
        //ParentT<Parent> d;
        //InterfaceT<String> e;
    }

}

class NoneDefaultConsructorClass
{
    public NoneDefaultConsructorClass(int a) { }
}

class Parent { }
class Child : Parent { }

// Ŭ�������� ����ϴ� ���׸� �ڷ����� ���� ������ ����� �� �ִ�. 

class StructT<T> where T : struct { } // 1.����ü�� �����ϰ� �Ϸ��� ��� ������ �Ǵ�

class ClassT<T> where T : class { } // 2.Ŭ������ �����ϰ� �Ϸ��� ��� ������ �Ǵ�

class NewT<T> where T : new() { } // 3. �Ķ���Ͱ� ���� �⺻ �����ڸ� ������ Ŭ������ ���� 
                                  // �߻�Ŭ������ NEW�� �Ұ����ϱ� ������ ��� �Ұ����ϴ�
class ParentT<T> where T : Parent { } // 4. Parent Ŭ������ ����� Ŭ������ �����ϰ� �Ѵ�.

class InterfaceT<T> where T : IComparable { } // 5. IComparable �������̽��� ���� Ŭ������ �����ϰ� �Ѵ�.

class MultiT<T1, T2, T3> where T1 : struct where T2 : class where T3 : new() { } // 6. �������� ������ �� �� �ִ�.