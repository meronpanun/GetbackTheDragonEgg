using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : PlayerBullet
{
    private const int ICEATTACK= 1;

    private bool isStay = true;

    [SerializeField] // エディタ
    private AudioClip generateSoundEffect; // 生成時のSE

    private void Awake()
    {
        baseAttack = ICEATTACK;
    }

    protected override void Start()
    {
        base.Start();
        AudioSource.PlayClipAtPoint(generateSoundEffect, transform.position);
    }

    protected override void Update()
    {
        // キー入力の処理を書く
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // iceShooterがスペースキー長押しで弾を生成しているので
            // こちらは離して発射の処理を書く
            // そうすることでShooter側でInstantiateしたこれらのオブジェクトを
            // Shooterが記憶しなくていい　
            isStay = false;
            // 親子解除
            transform.parent = null;
        }

        if (isStay)
        {
            // 待機中はコドモドラゴンについていく
            // 左右で動きが違うからどうしようか
            // 移動のスクリプトをここに丸ごと書くこともできるが
            // ドラゴン側で親子登録して
            // こっちで解除したらいいのでは？　
            // つまりここでは何もしない
        }
        else
        {
            // 普通に進む
            // 画面外で消える処理はUpdateで行っているので
            // isStayが有効なら画面外で消えない　
            base.Update();
        }
    }
}
