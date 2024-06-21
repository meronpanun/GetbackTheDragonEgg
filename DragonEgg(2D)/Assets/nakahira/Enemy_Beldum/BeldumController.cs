using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeldumController : Enemy
{
    private const int BELDUMHP = 2;
    private const int BELDUMATTACK = 2;
    // 角速度。一フレームに何度回転できるか
    private int rotaSpeed = 1;
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
        // プレイヤーとの相対位置を確認して(自作関数)
        Vector2 relativeVec = UnitVector(PlayerController.player);
        // 角度を度数で導出
        // float angle = Vector3.SignedAngle(relativeVec, );
        // 自分が向いている方向と近い方向に回転
        //// とりあえずプレイヤーの方向に即座に回転→OK
        //transform.eulerAngles = new Vector3(0f, 0f, generalDec);
        // 角速度*一フレームの時間だけ回る
        //transform.Rotate(0f, 0f, rotaSpeed * Time.deltaTime);
        //transform.Translate(0f,0.1f,0f);
    }

    // 角度を取得してそれの一般角の方向のVector2を生成
    // private Vector2 AngleToVector
}
