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

        // �� Sphere ����
        GameObject newSphere = Instantiate(sphere1);
        newSphere.name = "newSphere";

        // �� ��ü�� ��ġ�� ��ü1�� ��ü2�� ���̿� �ΰ����
        // �� ��ü�� ����� ��ü1�� ��ü2�� rgb���� �� �߰������� �����ϰ� ����

        newSphere.transform.position = GetMiddle<Vector3>(sphere1.transform.position, sphere2.transform.position);
        newSphere.GetComponent<Renderer>().material.color = GetMiddle<Color>(sphere1Renderer.material.color, sphere2Renderer.material.color);

       // MyGeneric<int> myIntGeneric = new MyGeneric<int>(1);

       // print(myIntGeneric.GetSome()); // 1 // 

        MyGeneric<string> myStringGeneric = new MyGeneric<string>("a");
        print(myStringGeneric.GetSome()); // a // string

        // �Լ����� Generic �� ���� ������� ��ȯ �ڷ����� �����Ǿ� �־� ������ �ؾ��ϴ� �������� ����
        //(newSphere.GetComponent(typeof(Renderer)) as Renderer).material.color = 
        //    GetMiddle<Color>(sphere1Renderer.material.color, sphere2Renderer.material.color);


       // MyGeneric<GameObject> myGOGeneric = new MyGeneric<GameObject>(new GameObject());

       // myGOGeneric.GetSome().name = "MyGameObjectGeneric";
    }

    // ��ġ�� �߰����� ���ϴ� �Լ� 

    //private Vector3 GetMiddle(Vector3 a, Vector3 b)
    //{
    //    Vector3 @return = 
    //        new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);
    //    return @return;
    //}
    //// ���� �߰����� ���ϴ� �Լ�
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
