using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFryController : Enemy
{
    private const int DRAGONFRYATTACK = 1;
    private Rigidbody2D myRigid;
    // よける際の速さ
    private float DodgeForce;
    protected override void Start()
    {
        base.Start();
        attack = DRAGONFRYATTACK;
        myRigid = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Dodge()
    {
        // 左右のどちらによけるか。0が左、1が右
        int LeftOrRight = Random.Range(0, 1);
        if (LeftOrRight == 0)
        {
            // 0の場合ちょっと-1に矯正させてもらいますね
            LeftOrRight = -1;
        }
        // 上下の角度
        float direction = Random.Range(-30.0f, 30.0f);
        // 移動するベクトルを作成
        Vector2 dodgeDir = new Vector2(Mathf.Cos(direction) * DodgeForce * LeftOrRight, Mathf.Sin(direction) * DodgeForce);
        // 実行
        myRigid.AddForce(dodgeDir);
    }
}