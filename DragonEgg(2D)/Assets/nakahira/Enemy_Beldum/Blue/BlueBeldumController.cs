using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueBeldumController : Enemy
{
    private const int BELDUMHP = 5;
    private const int BELDUMATTACK = 4;
    // 角速度。1秒に何度回転できるか
    private int rotaSpeed = 60;
    // 速さ(これが角度で分解される)
    private float moveSpeed = 0.8f;
    // 起動してnフレーム後にまっすぐ飛ぶようにする
    private int lifeSpan = 600;
    // 自分がどこ向いているか
    Vector2 myAngleVector;

    // 回転してもいいか
    private bool canRotate = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // 攻撃力とHPを設定
        hitPoint = BELDUMHP;
        attack = BELDUMATTACK;
        canShoot = false; // 一応使わない機能はオフにしておく
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        base.Move();
        lifeSpan--;
        if (lifeSpan > 0)
        {
            // ホーミング機能つける
            // プレイヤーとの相対位置を確認して(自作関数)
            Vector2 relativeVec = UnitVector(PlayerController.player);
            //Debug.Log(relativeVec);
            // 自分がどこ向いてるかもベクトルにして
            myAngleVector = GeneralAngleToVector2(transform.localEulerAngles.z - 90f);
            // 自分の向きとの角度を度数で導出
            float angle = Vector2.SignedAngle(myAngleVector, relativeVec);
            // 自分が向いている方向と近い方向に回転

            // あとは自分の向いてる向きに向かって進む
            MoveByMyAngle();

            if (!canRotate) return; // 回転しちゃダメならここで終了

            if (angle < 0)
            {
                // 時計回りの方が近いとき
                transform.eulerAngles -= new Vector3(0f, 0f, rotaSpeed * Time.deltaTime);
            }
            else
            {
                // 反時計回りの方が近いとき
                transform.eulerAngles += new Vector3(0f, 0f, rotaSpeed * Time.deltaTime);
            }
        }
        else
        {
            // まっすぐ飛ぶ
            MoveByMyAngle();
        }
    }

    private void MoveByMyAngle()
    {
        transform.position += (Vector3)(myAngleVector * moveSpeed * Time.deltaTime);
    }

    // その名の通り0～360を単位ベクトルにします
    private Vector2 GeneralAngleToVector2(float angle)
    {
        Vector2 result = Vector2.one;

        result.x = Mathf.Cos(angle * Mathf.Deg2Rad);
        result.y = Mathf.Sin(angle * Mathf.Deg2Rad);

        // Debug.Log($"関数で出てる結果:{result}");
        return result;
    }

    protected override void OnDeath()
    {
        // 当たり判定を消す
        GetComponent<CapsuleCollider2D>().enabled = false;
        lifeSpan = 0;
        base.OnDeath();
    }
}
