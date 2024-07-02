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
    public GameObject bullet;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 3;
        attack = 1;
        speed.y = -0.5f;
        shootSpan = 1;
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
        transform.Translate(speed.x * Time.deltaTime, speed.y * Time.deltaTime, 0f);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // プレイヤーに向けて球を撃つ処理
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<ORBBulletController>().SetAngle(UnitVector(PlayerController.player)); // Vector2にVector3ぶち込んで大丈夫かなあ
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canShoot = false;
        GetComponent<CircleCollider2D>().enabled = false; // 各オブジェクトのコライダーを各自で切ること。
    }
}
