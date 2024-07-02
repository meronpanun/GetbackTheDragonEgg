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
        // いつものようにプレイヤーの位置に球を
        Vector2 playerVec = UnitVector(PlayerController.player);
        // 生成して
        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<DragonFryBulletController>().SetAngle(playerVec);
    }
}