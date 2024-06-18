using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    public Bullet bulletPrefab;
    public Transform shotPoint;

    public float damage = 10f;

    public float maxHP = 100;
    public float currentHP = 100;

    public void Hit(float damage)
    {
        currentHP -= damage;
        print($"Player take damage : {damage}, current HP : {currentHP}");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    public void Shot()
    {
        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse); // 이부분 한번 찾아볼것

        bullet.damage = damage;
        // bullet에게 맞아야 할 대상의 Layer를 설정
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Monster"));

        Destroy(bullet, 3f);
    }
}
