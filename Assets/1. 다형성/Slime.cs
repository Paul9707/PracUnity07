using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster, IHitable
{
    public void Start()
    {
        maxHP = 100f;
        currentHP = maxHP;
    }
    
}
