using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// abstract 를 붙여 추상클래스로 만들어라
public class Monster : MonoBehaviour, IHitable
{
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;    

    public GameObject bulletPrefab; // Bullet 프리팹을 담을 변수
    public Transform shotPoint; // 총알이 발사될 위치

    public float shotInterval = 1.1f; // 총알이 발사되는 주기

    private void Start()
    {
        StartCoroutine(ShotCoroutine());
    }

 
    public virtual void Hit(float damage)
    {
        currentHP -= damage;
        print($"{name} Take Damage : {damage}, current HP: {currentHP}");
    }

    IEnumerator ShotCoroutine()
    {
        if (bulletPrefab == null || shotPoint == null)
        {
            yield break;
        }
        while (true)
        {
            Shot(damage);

            yield return new WaitForSeconds(shotInterval);
        }
    }

    public void Shot(float damage)
    {
        // 총알을 생성하고 발사하는 코드
        GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        // 총알에 힘을 가해주는 코드(rigidbody를 참조 및 Addforce를 통해 앞으로 날라가게 함)
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse); // 이부분 한번 찾아볼것
        // 총알에 데미지를 전달하는 코드

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        // player랑만 상호작용 해라
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");
        // 3초후 삭제
        Destroy(bulletObject, 3f);
    }

}
