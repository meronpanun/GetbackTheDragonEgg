using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class ORBController : Enemy
{

    public float cycleSpeed = 5f; // 大きくすれば回転周期が小さくなり、より早く往復します。
    public float moveSpeed = 5f; // 大きくすればより早く移動し、半径が大きくなります。

    private float angle; // 角度の計算に使うタイマー
    private float shootTimer; // 弾の発射を制御するタイマー
    private float shootSpan = 2; // 何秒おきに弾を発射するか

    private bool canMove = true; // 動けるか
    private bool canShoot = true;  // 弾撃てるか

     //プレハブなのでエディタからよろしく
    public GameObject bullet;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 3;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        angle += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (canMove) // 動く関連の処理
        {
            speedx = (float)Math.Cos(angle * cycleSpeed) * moveSpeed;
            transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0f);
        }

        if (canShoot)
        {
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                // プレイヤーに向けて球を撃つ処理
                GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletInstance.GetComponent<ORBBulletController>().speed = UnitVector(PlayerController.player); // Vector2にVector3ぶち込んで大丈夫かなあ
            }
        }
    }


}
