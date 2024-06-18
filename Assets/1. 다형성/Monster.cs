using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// abstract �� �ٿ� �߻�Ŭ������ ������
public class Monster : MonoBehaviour, IHitable
{
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;    

    public GameObject bulletPrefab; // Bullet �������� ���� ����
    public Transform shotPoint; // �Ѿ��� �߻�� ��ġ

    public float shotInterval = 1.1f; // �Ѿ��� �߻�Ǵ� �ֱ�

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
        // �Ѿ��� �����ϰ� �߻��ϴ� �ڵ�
        GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        // �Ѿ˿� ���� �����ִ� �ڵ�(rigidbody�� ���� �� Addforce�� ���� ������ ���󰡰� ��)
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse); // �̺κ� �ѹ� ã�ƺ���
        // �Ѿ˿� �������� �����ϴ� �ڵ�

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        // player���� ��ȣ�ۿ� �ض�
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");
        // 3���� ����
        Destroy(bulletObject, 3f);
    }

}
