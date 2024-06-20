using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeldumController : Enemy
{
    private const int BELDUMHP = 2;
    private const int BELDUMATTACK = 2;
    // 角速度。一秒間に何度回転できるか
    private int rotaSpeed = 60;
    // 現在の頭の位置。初期の下向きは0°
    private int angle = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // 攻撃力とHPを設定
        hitPoint = BELDUMHP;
        attack = BELDUMATTACK;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        base.Move();
        // ホーミング機能つける
        // プレイヤーとの相対位置を確認して
        Vector2 relativePos = UnitVector(PlayerController.player);
        // 角度を導出
        //Mathf.Atan2();
        // 自分が向いている方向と近い方向に回転
        // 角速度*一フレームの時間だけ回る
        transform.Rotate(0f, 0f, rotaSpeed * Time.deltaTime);
        transform.Translate(0f,0.1f,0f);
    }
}
