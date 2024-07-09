using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORBBulletController : EnemyBullet
{
    private const int ORBBULLETATTACK = 1;
    private const float SPEED = 1;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attack = ORBBULLETATTACK;
        speed = SPEED;
    }
}
