using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class ORBController : Enemy
{

    protected float cycleSpeed = 2f; // 大きくすれば回転周期が小さくなり、より早く往復します。
    protected float moveSpeed = 2f; // 大きくすればより早く移動し、半径が大きくなります。

    protected float angle; // 角度の計算に使うタイマー
    protected float shootTimer; // 弾の発射を制御するタイマー
    protected float shootSpan = 2; // 何秒おきに弾を発射するか

     //プレハブなのでエディタからよろしく
    public GameObject bullet;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 3;
        attack = 1;
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
        speedx = (float)Math.Cos(angle * cycleSpeed) * moveSpeed;
        transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0f);
    }

    protected override void Shoot()
    {
        base.Shoot();
        shootTimer += Time.deltaTime;
        if (shootTimer > shootSpan)
        {
            shootTimer = 0;
            // プレイヤーに向けて球を撃つ処理
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<ORBBulletController>().speed = UnitVector(PlayerController.player); // Vector2にVector3ぶち込んで大丈夫かなあ
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canShoot = false;
        GetComponent<CircleCollider2D>().enabled = false; // 各オブジェクトのコライダーを各自で切ること。
    }
}
