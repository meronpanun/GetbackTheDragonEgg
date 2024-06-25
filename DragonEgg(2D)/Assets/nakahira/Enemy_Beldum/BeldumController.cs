using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeldumController : Enemy
{
    private const int BELDUMHP = 2;
    private const int BELDUMATTACK = 2;
    // 角速度。1秒に何度回転できるか
    private int rotaSpeed = 60;
    // 速さ
    private float speed = 0.5f;
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
        Debug.Log(relativeVec);
        // 自分がどこ向いてるかもベクトルにして
        Vector2 myAngleVector = GeneralAngleToVector2(transform.localEulerAngles.z);
        // 自分の向きとの角度を度数で導出
        float angle = Vector2.SignedAngle(myAngleVector, relativeVec);
        // 自分が向いている方向と近い方向に回転
        if (angle < 0)
        {
            // 時計回りの方が近いとき
            transform.Rotate(0f, 0f, -rotaSpeed * Time.deltaTime);
        }
        else
        {
            // 反時計回りの方が近いとき
            transform.Rotate(0f, 0f, rotaSpeed * Time.deltaTime);
        }
        // あとは自分の向き + 270度に合わせて進む
        Vector2 temp = relativeVec * speed * Time.deltaTime;
        //Debug.Log($"こいつの進んでる向き:x = {(relativeVec.x > 0 ? "右" : "左")}, y = {(relativeVec.y > 0 ? "上" : "下")}");
        //Debug.Log($"最終的な速さ：{temp}");
        transform.Translate(temp);
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
}
