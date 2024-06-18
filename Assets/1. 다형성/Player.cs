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

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse); // �̺κ� �ѹ� ã�ƺ���

        bullet.damage = damage;
        // bullet���� �¾ƾ� �� ����� Layer�� ����
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Monster"));

        Destroy(bullet, 3f);
    }
}
