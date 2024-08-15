using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBulletController : PlayerBullet
{
    private const int attack = 1;

    private void Awake()
    {
        baseAttack = attack;
    }
}
