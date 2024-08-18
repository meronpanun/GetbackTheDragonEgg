using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;

public class IceShooter : Shooter
{
    // リソースファイルからロード
    private GameObject iceBullet;

    // Find
    private GameObject chargeMeter;
    private PlayerChargeMeterController meter;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // 補正です。

    private float timer = 0; // いつもの
    private const float iceBulletInterval = 0.2f; // 次の弾が生成される間隔
    private float instantiateThreshold = iceBulletInterval; // 動的に変わる
    private int bulletCount = 0; // 今何個の弾が出現しているか
    private int bulletAngle = 30; // 何度回転するか
    private int angleOffset = 0; // その名の通り
    private const int maxBulletCount = 7; // 最大何個出現させられるか
                                          // ここで悲報です
                                          // 途中から定数をロワーキャメルケースで書いてました
                                          // 今更変えれません　
    private float meterFactor = 1 / (iceBulletInterval * maxBulletCount);
    private AudioClip se; // リソース
    private bool isPlayedSE = false; // 今回の弾生成でSEを鳴らしたかどうか

    private void Start()
    {
        Debug.Log(iceBulletInterval * maxBulletCount);
        iceBullet = (GameObject)Resources.Load("IceBullet");
        se = (AudioClip)Resources.Load("IceCharge");

        // アタッチされているドラゴンが右か左かで
        // 弾を生成する向きを変える
        // チャージメーターの左右も変える　
        if (gameObject.name == "ChildDragonRight")
        {
            bulletAngle *= -1;
            angleOffset *= -1;
            chargeMeter = GameObject.Find("RightChargeMeter");
        }
        else
        {
            chargeMeter = GameObject.Find("LeftChargeMeter");
        }
        // コンポーネント取得
        meter = chargeMeter.transform.GetChild(0).GetComponent<PlayerChargeMeterController>();
    }

    void Update()
    {
        if (!canShoot) return;
        // スペースキーで弾を発射。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // 何もなし
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            // 長押ししていると弾が次々に生成
            timer += Time.deltaTime;

            if (bulletCount >= maxBulletCount) return; // 指定以上なら生成しない

            if (!isPlayedSE) // ここを通った時一回だけ流れる
            {
                // まだ再生されていなかったら
                GameAudio.InstantiateSE(se);
                isPlayedSE = true;
            }

            if (timer > instantiateThreshold)
            {
                // 回転を生成
                Quaternion bulletRotation = Quaternion.AngleAxis(bulletAngle * bulletCount + angleOffset, Vector3.forward);

                // インスタンス化 親は自分にして、追尾させる
                Instantiate(iceBullet, 
                    transform.position + bulletRotation * instanceOffset, // Quaternionでベクトルが回転できるのがアツい
                    bulletRotation,
                    transform);

                bulletCount++;
                // ここでまたInterval秒後に生成されるようにする
                // Timerを蓄積させたかったため
                instantiateThreshold = iceBulletInterval * (bulletCount + 1);
                isPlayedSE = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            // 移動する処理は弾自身に持たせている
            // 弾の数もリセット
            bulletCount = 0;
            // タイマー関連もリセット
            timer = 0;
            instantiateThreshold = iceBulletInterval;
            isPlayedSE = false; // SEフラグもリセット
        }

        Debug.Log($"タイマー{timer}");
        // メーター描画
        Debug.Log($"メーターの量{timer * meterFactor}");
        meter.FillMeter(timer * meterFactor);
    }
}
