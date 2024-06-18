using System;
using System.Collections;
using System.Collections.Generic; // .NET�� ����Ǿ� �ִ� 
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    /* ���� ���� ���� (�÷���)

   �����͸� ���� ������ ����� �� �ִ� Ŭ������ ����
  - �迭 
  - ����Ʈ (��̸���Ʈ)
  - ��ųʸ�(�ؽ����̺�)
  - ť 
  - ���� 
   */
    #region �迭
    /*1. �迭
     ex) private int[] intarray-> int�� �迭

   �� �⺻������ �迭�� ���۷��� Ÿ���̱� ������ �ʱ�ȭ �Ҵ��� ���� ������ null�� �߻��Ѵ�.
   �� ���� int[] intarray = new int[5]; �� ���� �ʱ�ȭ �Ҵ��� ���־�� �Ѵ�.
   �� int�� ���� ���ͷ� Ÿ���� �ʱⰪ�� �Ҵ����� �ʾƵ� �⺻���� �Ҵ��.
    */



    private int[] intArray = new int[5];
   private int someInt;

   public int[] publicIntArray = new int[10]; // �ν����� â���� �Ҵ��ߴٸ� start���� ���� ����Ǽ� null�� ���� �ʴ´�. �� �ʱⰪ�� �Ҵ��ص� �ν�����â���� �ִ� ������ ����ȴ�.

    #endregion

    #region ����Ʈ
    /*
      2. ����Ʈ
        �� �迭�� ����� ����� �Ѵ�.
        �� ���������� ũ�� ������ �����ϴ�.
        �� ��� �� ���� ����� �����ϴ� �Լ��� ���Ե� Ŭ���� 
     */

    private List<int> intList = new List<int>();
    
    public List<int> publicIntList;

    public List<GameObject> gameObjects;

    private ArrayList arrayList = new ArrayList(); // ArrayList�� ���׸��� �ƴ� object�� ����Ѵ�. ���� ����ȯ�� ���־�� �Ѵ�.
                                                   // ���� ArrayList�ȿ��� ��� Ÿ���� ���� �� �ִ�. arrayList�ȿ� arrayList�� ����
                                                   // �⺻������ �ڽ��� �Ǿ ����.
                                                   // ArrayList�� List�� ���� ���·� Ȱ�� �� �� ������.
                                                   // �������� �ڷ����� �������� ������, �⺻������ Boxing�Ǿ� �Ҵ�ȴ�.
                                                   // ���� ���ɻ��� �̽��� �߻��� �� �ִ�.
    public ArrayList pulicArrayList;               // �ν����� â���� �Ҵ��� �ȵǱ� ������ ����Ƽ������ Ȱ�뵵�� ������
                                                   // ����Ʈ�� ��� Add�� �ɰ�� �⺻���� �����ϰ� �׵ڿ� �߰��ϴ� ����̴� ���� ���Ի����� ������ �����ս��� ������ �� �ִ�.

    #endregion

    #region ��ųʸ�

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>(); // ��ųʸ��� Ű�� ������ �̷���� �����͸� �����ϴ� �ڷᱸ��
                                                                                              // �ؽ����̺��̶�� ������ Ȱ���ؼ� ���� ã�� ������ �˻��ӵ��� ������.
                                                                                              // �迭�� �������⵵�� ������ſ� �ð����⵵�� ���� �ڷᱸ�����.
                                                                                              // ��ųʸ��� �ð����⵵�� ���� ��� �������⵵�� ����. Ÿ�뽺�� Ž���ϴ°Ͱ� ����-> �ݾ� ���ְ��鼭 Ž��
                                                                                              // ���� �뷮�� �����͸� �����Ҷ��� ��ųʸ��� ����ϴ°��� ����.
    private Hashtable hashtable = new Hashtable();
    // �� �� ������� �ʴ´� ��ųʸ��� �̰� ������� ���������. ���� ��ųʸ��� ����ϴ°��� ����.
    public Dictionary<string, GameObject> publicDictionary; // �ν�����â���� �Ҵ��� �ȵȴ�.                                             
    #endregion


    #region ����/ ť
    // ����

    private Stack<int> intStack = new Stack<int>();


    // ť
    // �� ���� ����  �ӽõ����ͷ� ������ �޸� ������ �������� �ʴ´�.

    private Queue<int> intQueue = new Queue<int>();
      
     
    #endregion
    //������Ƽ 
    int a { get; set; }
    /*
    �� ĸ��ȭ�� ������ �ִ�.     
     */
    
    private void Start()
    {

        Array.Fill<int>(intArray, 1); // using System;�� �߰��ؾ� ��밡��

        /* for (int i = 0; i < intArray.Length; i++)
         {
             print(intArray[i]);
         }*/
        /*
         foreach (int someInt in publicIntArray) // intArray�� ������ someInt�� �־��ش�.
        {
            print(someInt);
        }
        */

        //intList.Add(1);
        //intList.Add(2);
        //intList.Add(3);
        //intList.Add(4);
        //intList.Add(5);
        // Add()�� ���� ����Ʈ�� ��Ҹ� �߰��� �� �ִ�. Add�� ȣ���� ��ŭ ���������� ũ�Ⱑ ����
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
        //arrayList.Add(new GameObject("���� ���� ��ü"));
        //arrayList.Add(new ArrayList());

        //foreach (object element in arrayList)
        //{
        //    print(element);
        //}

        //print((arrayList[2] as GameObject).name); // as�� ���� ����ȯ�� �� �� �ִ�. ����ȯ�� �� �� ���ٸ� null�� ��ȯ�Ѵ�.

        //dictionary.Add("cube", cube);
        //dictionary.Add("sphere", sphere);
        //dictionary.Add("cylinder", cylinder);
        //dictionary.Add("capsule", capsule);

        ////����Ʈ ���� 
        //print(intList[0]);

        //// ��ųʸ� ���� 
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

