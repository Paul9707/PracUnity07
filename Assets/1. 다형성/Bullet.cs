using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;
    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���� �ȿ� ���� ��ü�� Layer�� targetLayer�� ���� �ʴٸ� �����Ѵ�.
        if ((targetLayer | (1 << other.gameObject.layer)) != targetLayer) 
        {
            return;
        }
        // �̰� �������� ���
        if (other.TryGetComponent<IHitable>(out IHitable hitable))// ��ȯ���� �Ҹ���
         {
             hitable.Hit(damage);   
         }

        // �̰� ����Ƽ�� ��� -> �������� ������ �Ҷ� ��� ������ ������ ����ض�
        // other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);
        
        Destroy(gameObject);
    }
}
