using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDragonFryBulletController : EnemyBullet
{
    private const int BULLETATTACK = 2;
    private const float SPEED = 2f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attack = BULLETATTACK;
        speed = SPEED;
    }
}
