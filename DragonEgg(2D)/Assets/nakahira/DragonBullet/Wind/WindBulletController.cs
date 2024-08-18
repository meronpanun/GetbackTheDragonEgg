using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBulletController : PlayerBullet
{
    private const int attack = 1;
    [SerializeField]
    private AudioClip se;

    private void Awake()
    {
        baseAttack = attack;
    }

    protected override void Start()
    {
        base.Start();
        GameAudio.InstantiateSE(se);
    }
}
