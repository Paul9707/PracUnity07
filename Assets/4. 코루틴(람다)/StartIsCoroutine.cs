using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIsCoroutine : MonoBehaviour
{
    // Start �޽��� �Լ��� ��ȯ���� IEnumerator�� ��� �ڵ����� �ڷ�ƾ�� �ȴ�.
    IEnumerator Start()
    {
        print(@"""Start"" strat.");
        yield return new WaitForSeconds(5.0f);
        print(@"""Start"" end.");
    }
}
