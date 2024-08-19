using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDragonFryController : Enemy
{
    private const int DRAGONFRYATTACK = 1;
    private const float SHOOTSPAN = 1;
    private Rigidbody2D myRigid;
    // よける際の速さ
    private float dodgeForce = 250;
    // 帰るときのスピード
    private float exitForceX = 10f;
    private float exitForceY = -1f;
    // エディタで
    public GameObject bulletPrefab;
    // 何秒で退場するか
    private const float LIFESPAN = 10f;
    private float timer = 0;
    // Start時に左にはけるか右にはけるか決めておく
    private int leftOrRight = 0;

    private const float DODGEINCREACE = 1.5f;
    private float blueDodgeInterval = DODGEINCREACE;
    protected override void Start()
    {
        base.Start();
        attack = DRAGONFRYATTACK;
        myRigid = GetComponent<Rigidbody2D>();
        shootSpan = SHOOTSPAN;
        // 左右のどちらによけるか。-1が左、1が右
        leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {
            leftOrRight = -1;
        }
        // 最初だけちょっと前に出る
        myRigid.AddForce(Vector2.down * 200);
    }

    protected override void Update()
    {
        base.Update();
        // タイマー加算
        timer += Time.deltaTime;

        // 寿命を超えていれば
        if (timer > LIFESPAN)
        {
            // 退場するためにAddForceしている
            Exit();
        }
        else if (timer > blueDodgeInterval)
        {
            // 青い奴は一定時間ごとに勝手にぴょんぴょんする
            // Exit()とは同時に起きない
            Dodge();
            blueDodgeInterval += DODGEINCREACE;
        }
    }

    private void Exit()
    {
        // 移動
        myRigid.AddForce(new Vector2(exitForceX * leftOrRight, 0f));
        // X方向は加速、Y方向は等速
        transform.Translate(0f, exitForceY * Time.deltaTime, 0f);
    }

    public void Dodge()
    {
        // 左右のどちらによけるか。0が左、1が右
        int leftOrRight = 1;
        // ワールド座標より右にいたら
        if (transform.position.x > 0)
        {
            // -1に矯正させてもらいますね
            leftOrRight = -1;
        }
        // 上下の角度(ラジアン化)
        float direction = Random.Range(-10f, 10f) * Mathf.Deg2Rad;
        // 移動するベクトルを作成
        Vector2 dodgeDir = new Vector2(Mathf.Cos(direction) * dodgeForce * leftOrRight, Mathf.Sin(direction) * dodgeForce);
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