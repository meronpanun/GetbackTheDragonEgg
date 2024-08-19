using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public class ORBController : Enemy
{

    protected float cycleSpeed = 2f; // 大きくすれば回転周期が小さくなり、より早く往復します。
    protected float moveSpeedX = 2f; // 大きくすればより早く移動し、半径が大きくなります。

    protected float angle; // 角度の計算に使うタイマー

     //プレハブなのでエディタからよろしく
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 3;
        attack = 1;
        speed.y = -0.5f;
        shootSpan = 2;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Move() // これUpdate内で実行されてることわかんなくね？
    {
        base.Move();
        angle += Time.deltaTime;
        speed.x = (float)Math.Cos(angle * cycleSpeed) * moveSpeedX;

        transform.Translate(speed.x * Time.deltaTime, 0f, 0f);

        // なまじ継承してるからこんな条件分岐がいる…
        if (gameObject.CompareTag("Boss")) return;

        transform.Translate(0f, speed.y * Time.deltaTime, 0f);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // プレイヤーに向けて球を撃つ処理
        // 発射
        InstantiateBulletToAngle(bulletPrefab, UnitVector(PlayerController.player));
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canShoot = false;
        GetComponent<CircleCollider2D>().enabled = false; // 各オブジェクトのコライダーを各自で切ること。
    }
}
