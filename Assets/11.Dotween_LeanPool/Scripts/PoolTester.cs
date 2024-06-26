using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTester : MonoBehaviour
{
    public ObjectPool pool;

    private void Awake()
    {
        if (pool == null)
        {
            pool = GetComponent<ObjectPool>();
        }
    }

    // ��ư���� ȣ���� �Լ� 
    public void SpawnSphere()
    {
        GameObject obj = pool.GetObject();
        // insideUnitSphere: Vector3�� ��ȯ�� �Ǹ� x,y,z���� -1~1 ���̰����� ��ȯ
        obj.transform.position = Random.insideUnitSphere * 5f;
        StartCoroutine(DespawnCoroutine(obj));
    }

    // 2~5�� �Ŀ� ������Ʈ Ǯ�� ��ȯ
    IEnumerator DespawnCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(2f,5f));
        pool.ReturnObject(obj);
    }
}
