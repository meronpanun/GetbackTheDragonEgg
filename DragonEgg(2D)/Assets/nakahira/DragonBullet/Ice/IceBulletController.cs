using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : PlayerBullet
{
    private const int ICEATTACK= 1;
    protected override void Start()
    {
        base.Start();
        baseAttack = ICEATTACK;
    }
}
