using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFryController : Enemy
{
    private const int DRAGONFRYATTACK = 1;
    private const float SHOOTSPAN = 1;
    private Rigidbody2D myRigid;
    // よける際の速さ
    private float DodgeForce = 250;
    // エディタで
    public GameObject bulletPrefab;
    // 何秒で退場するか
    private const float LIFESPAN = 5f;
    private float timer = 0;
    protected override void Start()
    {
        base.Start();
        attack = DRAGONFRYATTACK;
        myRigid = GetComponent<Rigidbody2D>();
        shootSpan = SHOOTSPAN;
    }

    protected override void Update()
    {
        base.Update();
        // タイマー加算
        timer += Time.deltaTime;
        // 寿命を超えていなければこの先の処理は実行されない
        if (timer > LIFESPAN) return;
        // 退場するためにAddForceしている
    }

    public void Dodge()
    {
        // 左右のどちらによけるか。0が左、1が右
        int LeftOrRight = 1;
        // ワールド座標より右にいたら
        if (transform.position.x > 0)
        {
            // -1に矯正させてもらいますね
            LeftOrRight = -1;
        }
        // 上下の角度(ラジアン化)
        float direction = Random.Range(-10f, 10f) * Mathf.Deg2Rad;
        // 移動するベクトルを作成
        Vector2 dodgeDir = new Vector2(Mathf.Cos(direction) * DodgeForce * LeftOrRight, Mathf.Sin(direction) * DodgeForce);
        // 実行
        myRigid.AddForce(dodgeDir);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // いつものようにプレイヤーの位置を調べ
        Vector2 playerVec = UnitVector(PlayerController.player);
        // 背後にいたら打てない
        if (playerVec.y > 0) return;
        // 発射
        InstantiateBulletToAngle(bulletPrefab, playerVec);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        gameObject.GetComponent<CircleCollider2D>().enabled = false; // 各オブジェクトのコライダーを各自で切ること。
    }
}