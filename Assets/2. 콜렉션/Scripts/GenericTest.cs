using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGeneric<SomeType> where SomeType : class, ICloneable
 {
    private SomeType someVal;

    public MyGeneric(SomeType someVal)
    {
        this.someVal = someVal;
    }
    public SomeType GetSome() { return someVal; }

    public SomeType GetClone() { return someVal; }
 }

public class GenericTest : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;

    // 
    public Action<int, int, int> someAction;

    public Func<int, int, float> someFunc;
    public void SomeAction(int a, int b, int c)
    {

    }
    public float SomeFunc(int a, int b)
    {
        return default;
    }

    private void Start()
    {
        someAction = SomeAction;
        someFunc = SomeFunc;

        Renderer sphere1Renderer = sphere1.GetComponent<Renderer>();
        Renderer sphere2Renderer = sphere2.GetComponent<Renderer>();
        sphere1Renderer.material.color = Color.red;
        sphere2Renderer.material.color = Color.blue;

        // 새 Sphere 생성
        GameObject newSphere = Instantiate(sphere1);
        newSphere.name = "newSphere";

        // 새 구체의 위치를 구체1과 구체2의 사이에 두고싶음
        // 새 구체의 색깔과 구체1과 구체2의 rgb값을 딱 중간값으로 설정하고 싶음

        newSphere.transform.position = GetMiddle<Vector3>(sphere1.transform.position, sphere2.transform.position);
        newSphere.GetComponent<Renderer>().material.color = GetMiddle<Color>(sphere1Renderer.material.color, sphere2Renderer.material.color);

       // MyGeneric<int> myIntGeneric = new MyGeneric<int>(1);

       // print(myIntGeneric.GetSome()); // 1 // 

        MyGeneric<string> myStringGeneric = new MyGeneric<string>("a");
        print(myStringGeneric.GetSome()); // a // string

        // 함수에서 Generic 을 쓰지 않을경우 반환 자료형이 고정되어 있어 언방식을 해야하는 불편함이 있음
        //(newSphere.GetComponent(typeof(Renderer)) as Renderer).material.color = 
        //    GetMiddle<Color>(sphere1Renderer.material.color, sphere2Renderer.material.color);


       // MyGeneric<GameObject> myGOGeneric = new MyGeneric<GameObject>(new GameObject());

       // myGOGeneric.GetSome().name = "MyGameObjectGeneric";
    }

    // 위치의 중간값을 구하는 함수 

    //private Vector3 GetMiddle(Vector3 a, Vector3 b)
    //{
    //    Vector3 @return = 
    //        new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);
    //    return @return;
    //}
    //// 색의 중간값을 구하는 함수
    //private Color GetMiddle(Color a, Color b)
    //{
    //    Color @return =
    //        new Color((a.r + b.r) / 2, (a.g + b.g) / 2,(a.b + b.b) / 2);
    //    return @return;
    //}

    private T GetMiddle<T>(T a, T b) where T : struct
    {
        dynamic da = a;
        dynamic db = b;
        dynamic c = (da + db) / 2;

        return (T)c;
    }
}
