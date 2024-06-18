using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster, IHitable
{
    public string orcPassive = "��ũ�� �������� 10% �� �޽��ϴ�.";

    public void Start()
    {
        maxHP = 150f;
        currentHP = maxHP;
    }
    // �����Ǹ� �߱� ������ Monster�� hit�� �ƴ� Orc�� hit�� �����
    public override void Hit(float damage)
    {
        damage *= 0.9f;

        base.Hit(damage);
    }
}
