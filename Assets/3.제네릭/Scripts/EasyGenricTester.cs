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
        //cubeFrom의 colors, xPositions, scales 배열을 각각 복사하고 싶음 
        cubeTo.colors = ArrayCopy(cubeFrom.colors);
        cubeTo.xPositions = ArrayCopy(cubeFrom.xPositions);
        cubeTo.scales = ArrayCopy<float>(cubeFrom.scales);
    }

    // 제네릭을 사용하면 다양한 타입의 배열을 복사할 수 있음
    // 타입을 정의할경우 그 자료형밖에 쓰지 못해 여러개의 메서드를 만들어야 하지만 제네릭을 사용할 경우 그럴 필요가 없다.
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
    - 제네릭 할용 2가지

    1. 제네릭을 사용하여 정의된 클래스를 자료형으로 사용 또는 함수를 호출    
    ex) List<int> : List라는 클래스를 사용하는데, 안에서 취급될 자료형은 int
    ex) GetComponent<T>() : 게임 오브젝트에 부착된 컴포넌트를 찾는데, T클래스의 컴포넌트를 찾는다.

    2. 직접 제네릭을 사용한 클래스 또는 함수를 정의 

 
 
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

// 클래스에서 사용하는 제네릭 자료형의 제약 사항을 명시할 수 있다. 

class StructT<T> where T : struct { } // 1.구조체만 가능하게 하려는 경우 제약을 건다

class ClassT<T> where T : class { } // 2.클래스만 가능하게 하려는 경우 제약을 건다

class NewT<T> where T : new() { } // 3. 파라미터가 없는 기본 생성자를 정의한 클래스만 가능 
                                  // 추상클래스는 NEW가 불가능하기 때문에 사용 불가능하다
class ParentT<T> where T : Parent { } // 4. Parent 클래스를 상속한 클래스만 가능하게 한다.

class InterfaceT<T> where T : IComparable { } // 5. IComparable 인터페이스를 따른 클래스만 가능하게 한다.

class MultiT<T1, T2, T3> where T1 : struct where T2 : class where T3 : new() { } // 6. 여러개의 제약을 걸 수 있다.