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
        // 트리거 안에 들어온 객체의 Layer가 targetLayer와 같지 않다면 무시한다.
        if ((targetLayer | (1 << other.gameObject.layer)) != targetLayer) 
        {
            return;
        }
        // 이게 정석적인 방법
        if (other.TryGetComponent<IHitable>(out IHitable hitable))// 반환형이 불리언
         {
             hitable.Hit(damage);   
         }

        // 이게 유니티식 방법 -> 현업에서 빠르게 할때 사용 보통은 위에꺼 사용해라
        // other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);
        
        Destroy(gameObject);
    }
}
