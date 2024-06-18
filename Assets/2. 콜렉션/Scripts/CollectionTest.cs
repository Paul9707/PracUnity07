using System;
using System.Collections;
using System.Collections.Generic; // .NET에 내장되어 있는 
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    /* 오늘 수업 내용 (컬렉션)

   데이터를 묶음 단위로 취급할 수 있는 클래스의 집합
  - 배열 
  - 리스트 (어레이리스트)
  - 딕셔너리(해쉬테이블)
  - 큐 
  - 스택 
   */
    #region 배열
    /*1. 배열
     ex) private int[] intarray-> int형 배열

   ㄴ 기본적으로 배열은 레퍼런스 타입이기 떄문에 초기화 할당을 하지 않으면 null이 발생한다.
   ㄴ 따라서 int[] intarray = new int[5]; 와 같이 초기화 할당을 해주어야 한다.
   ㄴ int와 같이 리터럴 타입은 초기값을 할당하지 않아도 기본값이 할당됨.
    */



    private int[] intArray = new int[5];
   private int someInt;

   public int[] publicIntArray = new int[10]; // 인스펙터 창에서 할당했다면 start보다 먼저 실행되서 null이 나지 않는다. 단 초기값을 할당해도 인스펙터창에서 넣는 값으로 적용된다.

    #endregion

    #region 리스트
    /*
      2. 리스트
        ㄴ 배열과 비슷한 기능을 한다.
        ㄴ 유동적으로 크기 변경이 가능하다.
        ㄴ 요소 비교 등의 기능을 지원하는 함수가 포함된 클래스 
     */

    private List<int> intList = new List<int>();
    
    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList(); // ArrayList는 제네릭이 아닌 object를 사용한다. 따라서 형변환을 해주어야 한다.
                                                   // 따라서 ArrayList안에는 모든 타입을 넣을 수 있다. arrayList안에 arrayList도 가능
                                                   // 기본적으로 박싱이 되어서 들어간다.
                                                   // ArrayList는 List와 같은 형태로 활용 할 수 있지만.
                                                   // 데이터의 자료형을 제한하지 않으며, 기본적으로 Boxing되어 할당된다.
                                                   // 따라서 성능상의 이슈가 발생할 수 있다.
    public ArrayList pulicArrayList;               // 인스펙터 창에서 할당이 안되기 때문에 유니티에서는 활용도가 떨어짐
                                                   // 리스트에 경우 Add가 될경우 기본값을 복사하고 그뒤에 추가하는 방식이다 따라서 삽입삭제가 많으면 퍼포먼스가 떨어질 수 있다.

    #endregion

    #region 딕셔너리

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>(); // 딕셔너리는 키와 값으로 이루어진 데이터를 저장하는 자료구조
                                                                                              // 해쉬테이블이라는 구조를 활용해서 값을 찾기 때문에 검색속도가 빠르다.
                                                                                              // 배열은 공간복잡도가 낮은대신에 시간복잡도가 높은 자료구조라면.
                                                                                              // 딕셔너리는 시간복잡도가 낮은 대신 공간복잡도가 높다. 타노스가 탐색하는것과 같다-> 반씩 없애가면서 탐색
                                                                                              // 따라서 대량의 데이터를 저장할때는 딕셔너리를 사용하는것이 좋다.
    private Hashtable hashtable = new Hashtable();
    // ㄴ 잘 사용하진 않는다 딕셔너리가 이걸 기반으로 만들어진다. 따라서 딕셔너리를 사용하는것이 좋다.
    public Dictionary<string, GameObject> publicDictionary; // 인스펙터창에서 할당이 안된다.                                             
    #endregion


    #region 스택/ 큐
    // 스택

    private Stack<int> intStack = new Stack<int>();


    // 큐
    // ㄴ 선입 선출  임시데이터로 꺼내면 메모리 공간을 차지하지 않는다.

    private Queue<int> intQueue = new Queue<int>();
      
     
    #endregion
    //프로퍼티 
    int a { get; set; }
    /*
    ㄴ 캡슐화랑 연관이 있다.     
     */
    
    private void Start()
    {

        Array.Fill<int>(intArray, 1); // using System;을 추가해야 사용가능

        /* for (int i = 0; i < intArray.Length; i++)
         {
             print(intArray[i]);
         }*/
        /*
         foreach (int someInt in publicIntArray) // intArray를 순차해 someInt에 넣어준다.
        {
            print(someInt);
        }
        */

        //intList.Add(1);
        //intList.Add(2);
        //intList.Add(3);
        //intList.Add(4);
        //intList.Add(5);
        // Add()를 통해 리스트에 요소를 추가할 수 있다. Add를 호출한 만큼 가변적으로 크기가 변함
        /*  foreach (int someInt in intList)
          {
              print(someInt); 
          }
        */
        //foreach (GameObject Obj in gameObjects)
        //{
        //    print(Obj.name);
        //}
        //arrayList.Add(1);
        //arrayList.Add("Hello");
        //arrayList.Add(3.14f);
        //arrayList.Add(new GameObject("내가 만든 객체"));
        //arrayList.Add(new ArrayList());

        //foreach (object element in arrayList)
        //{
        //    print(element);
        //}

        //print((arrayList[2] as GameObject).name); // as를 통해 형변환을 할 수 있다. 형변환을 할 수 없다면 null을 반환한다.

        //dictionary.Add("cube", cube);
        //dictionary.Add("sphere", sphere);
        //dictionary.Add("cylinder", cylinder);
        //dictionary.Add("capsule", capsule);

        ////리스트 참조 
        //print(intList[0]);

        //// 딕셔너리 참조 
        //dictionary["cube"].GetComponent<Renderer>().material.color = Color.red;
        //dictionary["sphere"].GetComponent<Renderer>().material.color = Color.blue;
        //dictionary["cylinder"].GetComponent<Renderer>().material.color = Color.gray;
        //dictionary["capsule"].GetComponent<Renderer>().material.color = Color.green;

        //hashtable.Add("a", 1);
        //hashtable.Add(3f, new GameObject());


        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        print(intStack.Pop());
        print(intStack.Pop());
        print(intStack.Pop());

        intStack.Push(6);
        intStack.Push(7);
        print(intStack.Pop());
        print(intStack.Pop());
        print(intStack.Pop());
        print(intStack.Pop());

        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        intQueue.Dequeue();
        intQueue.Dequeue();
        intQueue.Dequeue();

        intQueue.Enqueue(4);
        intQueue.Enqueue(5);

        intQueue.Dequeue();
        intQueue.Dequeue();
        intQueue.Dequeue();
        intQueue.Dequeue();


    }

}

