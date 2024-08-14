using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShooter : MonoBehaviour
{
    // リソースファイルからロード
    private GameObject thunderBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.5f, 0); // 口元から発射するための補正です。

    private PlayerChargeMeterController meter;

    private float timer = 0; // いつもの
    private const int maxAttack = 8; // チャージ最大の攻撃力
    private const float maxChargeTime = 3; // 最大威力になるためのチャージ時間
    private const float meterFactor = 1 / maxChargeTime; // メーターをいじるための係数
    private const float maxBulletScale = 2; // 最大サイズ
    // 最大チャージ時間で最大サイズになるよ　な係数
    private const float maxScaleFacter = maxBulletScale / maxChargeTime;
    private const float maxAttackFacter = maxAttack / maxChargeTime;

    private float attack = 0; // 弾の攻撃力　チャージで変動

    private GameObject thunderBulletInstance; // インスタンス保存用
    private GameObject thunderBulletController; // コンポーネント保存用

    private void Start()
    {
        thunderBullet = (GameObject)Resources.Load("ThunderBullet");
        // これ左右でゲージ違うの何とかできないかな
        if (name == "ChildDragonRight")
        {
            meter = GameObject.Find("RightChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
        else
        {
            meter = GameObject.Find("LeftChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
    }

    private void Update()
    {
        // スペースキーで弾を発射。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // 弾を生成 親を自身に設定
            thunderBulletInstance = Instantiate(thunderBullet,
                transform.position + instanceOffset,
                Quaternion.identity,
                transform);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            timer += Time.deltaTime; // いつものごとくタイマー計測
            // 最大ため時間に達したら抑える
            if (timer > maxChargeTime)
            {
                timer = maxChargeTime;
            }

            // タイマーに応じてサイズを変更
            thunderBulletInstance.transform.localScale = new Vector3(
                timer * maxScaleFacter,
                timer * maxScaleFacter,
                1);

            // タイマーに応じて攻撃力を変更
            attack = timer * maxAttackFacter;
            // 攻撃力計算も長押し中毎フレーム行う
            // チェーンソーみたいになる
            thunderBulletInstance.GetComponent<ThunderBulletController>().SetAttack((int)attack);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            // 弾発射(親子解除)
            thunderBulletInstance.transform.parent = null;
            // 今のチャージ時間に則った攻撃力と弾サイズで放出される　
            timer = 0;
        }

        // 毎フレームゲージ描画
        meter.FillMeter(timer * meterFactor);
    }
}
