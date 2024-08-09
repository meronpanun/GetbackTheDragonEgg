using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : PlayerBullet
{
    private const int ICEATTACK= 1;

    private const float speedX = 1;
    private const float speedY = 1;

    public float angle = 0;

    protected override void Start()
    {
        base.Start();
        baseAttack = ICEATTACK;

        // ここでスピードを0に
        Stop();
    }

    protected override void Update()
    {
        base.Update();

        // キー入力の処理を書く
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // iceShooterがスペースキー長押しで弾を生成しているので
            // こちらは離して発射の処理を書く
            // そうすることでShooter側でInstantiateしたこれらのオブジェクトを
            // Shooterが記憶しなくていい　
            Go(angle);
        }
    }

    public void Go(float angle)
    {
        Vector2 temp = new Vector2(speedX, speedY);
        temp = Quaternion.Euler(0, 0, angle) * temp;
        bulletSpeedx = temp.x; // やっぱベクトルにしろよ
        bulletSpeedy = temp.y;
    }
}
