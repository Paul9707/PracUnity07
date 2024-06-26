using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �⺻���� ������ƮǮ
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();
    public int startCount = 10; // �����Ҷ� ������ ������Ʈ�� ��

    private void Start()
    {
        for (int i = 0; i < startCount; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count == 0)
        {
            GameObject obj = Instantiate(prefab, transform);
            pool.Enqueue(obj);

        }
        GameObject @return = pool.Dequeue();
        @return.SetActive(true);
        @return.transform.SetParent(null);
        return @return;
    }

    // �پ� ������Ʈ Ǯ�� ��ȯ
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pool.Enqueue(obj);
    }

    

}
