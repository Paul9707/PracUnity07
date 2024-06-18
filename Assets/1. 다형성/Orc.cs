using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster, IHitable
{
    public string orcPassive = "오크는 데미지를 10% 덜 받습니다.";

    public void Start()
    {
        maxHP = 150f;
        currentHP = maxHP;
    }
    // 재정의를 했기 때문에 Monster의 hit이 아닌 Orc의 hit이 실행됨
    public override void Hit(float damage)
    {
        damage *= 0.9f;

        base.Hit(damage);
    }
}
