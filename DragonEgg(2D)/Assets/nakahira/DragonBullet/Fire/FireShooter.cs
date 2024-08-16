using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;

public class FireShooter : Shooter
{
    // リソースファイルからロード
    private GameObject playerRapidBullet;
    private GameObject playerFireBullet;
    private PlayerChargeMeterController meter;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // 口元から発射するための補正です。

    private const float rapidFireCooldown = 0.5f; // クールタイム
    private float rapidFireTimer = rapidFireCooldown; // 最初は撃てる
    private const float fireInterval = 0.1f; // 連射炎を発射するまでの長押し時間
    private const float maxFireRateTime = 5f;// 最長の発射間隔になるまでの時間
    private const float maxFireRateTimeFactor = 1 / maxFireRateTime;// 掛け算用
    private float shootFireRate = 0; // (変数)発射間隔
    private const float recoverySpeed = 5; // ゲージの回復係数
    private float fireRateTimer = maxFireRateTime; // 発射間隔を制御するためのタイマー
    private float fireShootTimer = -fireInterval; // 初期値はfireInterval分減らしておく

    private void Start()
    {
        playerFireBullet = (GameObject)Resources.Load("PlayerFire");
        playerRapidBullet = (GameObject)Resources.Load("PlayerRapidBullet");

        // メーターを取得
        // 左右で条件分岐
        string temp = string.Empty;
        if (gameObject.name == "ChildDragonRight")
        {
            temp = "RightChargeMeterInside";
        }
        else
        {
            temp = "LeftChargeMeterInside";
        }
        meter = GameObject.Find(temp).GetComponent<PlayerChargeMeterController>();
    }

    void Update()
    {
        if (!canShoot) return;
        // タイマー加算
        rapidFireTimer += Time.deltaTime;

        // スペースキーで弾を発射。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // 速射弾のクールタイムを超えていれば
            if (rapidFireTimer > rapidFireCooldown)
            {
                // 自分の現在位置に弾のプレハブを召喚
                Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
                // クールタイムを課す
                rapidFireTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            fireShootTimer += Time.deltaTime;

            if (fireShootTimer < 0) return; // 炎が出るまでゲージは消費しない

            fireRateTimer -= Time.deltaTime;

            if (fireRateTimer < 0)
            {
                // 0いかになろうとしたら抑える
                fireRateTimer = 0;
            }
            // ここでfireRateTimerに応じてshootFireRateを変える
            if (fireRateTimer > 3)
            {
                shootFireRate = 0.07f;
            }
            else if (fireRateTimer > 1f)
            {
                shootFireRate = 0.15f;
            }
            else
            {
                shootFireRate = 0.3f;
            }
            //Debug.Log(fireRateTimer);
            //Debug.Log(shootFireRate);
            if (fireShootTimer > shootFireRate) // fireRate秒に一回炎が発射される
            {
                Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                fireShootTimer = 0; // タイマーリセット
            }
        }
        else
        {
            // 押していないとき、ゲージ回復。
            fireRateTimer += Time.deltaTime * recoverySpeed;
            if (fireRateTimer > maxFireRateTime)
            {
                // 幅抑える
                fireRateTimer = maxFireRateTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            fireShootTimer = -fireInterval; // fireTimerの初期値をfireInterval分ずらしておく
        }

        // 最後にゲージを描画
        meter.FillMeter(fireRateTimer * maxFireRateTimeFactor);
    }
}
