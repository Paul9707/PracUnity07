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

    // 버튼에서 호출할 함수 
    public void SpawnSphere()
    {
        GameObject obj = pool.GetObject();
        // insideUnitSphere: Vector3로 반환이 되면 x,y,z값이 -1~1 사이값으로 반환
        obj.transform.position = Random.insideUnitSphere * 5f;
        StartCoroutine(DespawnCoroutine(obj));
    }

    // 2~5초 후에 오브젝트 풀로 반환
    IEnumerator DespawnCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(2f,5f));
        pool.ReturnObject(obj);
    }
}
