using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouShooter : MonoBehaviour
{
    // リソースファイルからロード
    private GameObject hadouKen;
    private GameObject hadouBeam;
    // 出したビームをしばらく使うのでメンバー変数に入れる
    private GameObject beamInstance;

    private Vector3 instanceOffset = new Vector3(0, 0.2f, 0); // 口元から発射するための補正です。

    private int attack = 0;

    private float hadouKenTimer = 0;
    private const float hadouKenCoolTime = 0.2f;

    private float beamChargeTimer = 0;
    private const float beamChargeMax = 2f;
    // ビームチャージ時間の逆数を使って割り算の数を減らします。
    private const float chargeMeterFactor = 1 / beamChargeMax;

    private PlayerChargeMeterController chargeMeterUI;

    private Coroutine chargeMeterCoroutine = null; // 読んで字のごとくチャージメーター用の変数です。

    private void Start()
    {
        hadouKen = (GameObject)Resources.Load("HadouBullet");
        hadouBeam = (GameObject)Resources.Load("HadouBeamBase");
        chargeMeterUI = GameObject.Find("PlayerChargeMeterInside").GetComponent<PlayerChargeMeterController>();

        // Start時にPlayerPrefsから攻撃力を参照
        // もしデータが見つからなかったら初期値として1をセーブ　
        attack = PlayerPrefs.GetInt("Attack", 0);
        if (attack == 0)
        {
            attack = 1;
            PlayerPrefs.SetInt("Attack", 1);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        // Debug.Log(beamChargeTimer);

        // ビームが出てる間弾撃つのを禁止する
        if (beamInstance != null) return;

        // 波動拳クールタイマー加算
        hadouKenTimer += Time.deltaTime;

        // スペースキーで弾を発射。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // チャージメーターが仕事中ならもういいよって伝える
            // Debug.Log(chargeMeterCoroutine);
            if (chargeMeterCoroutine != null) { StopCoroutine(chargeMeterCoroutine); }
            
            // 一定時間のクールタイムを設ける常套手段
            if (hadouKenTimer > hadouKenCoolTime)
            {
                Instantiate(hadouKen, transform.position + instanceOffset, Quaternion.identity);

                hadouKenTimer = 0; // きちんと元に戻しておく
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            // スペースが押されている間、チャージする
            beamChargeTimer += Time.deltaTime;
            // 貯め値が最大になったらそれ以上はチャージしない
            if (beamChargeTimer > beamChargeMax)
            {
                beamChargeTimer = beamChargeMax;
            }
            // チャージ状況をUIに反映
            chargeMeterUI.FillMeter(beamChargeTimer * chargeMeterFactor);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            float reduceTime = 0.2f; // 戻るのに要する時間。ビームがちゃんと出る時以外は素早く戻る
            // キーを離したとき、チャージが最大ならビームが出る
            if (beamChargeTimer >= beamChargeMax)
            {
                beamInstance = Instantiate(hadouBeam);
                reduceTime = beamChargeMax; // チャージと同じ時間かけて戻り、撃ってる感じを出す
            }
            // そうでなくても波動拳のクールタイムが完了してたら普通の弾がでる
            else if (hadouKenTimer > hadouKenCoolTime)
            {
                Instantiate(hadouKen, transform.position + instanceOffset, Quaternion.identity);

                hadouKenTimer = 0; // きちんと元に戻しておく
            }
            // ビームのチャージをリセット
            beamChargeTimer = 0;
            // UIも与えられた速度で戻る
            chargeMeterCoroutine = StartCoroutine(chargeMeterUI.ReduceMeter(reduceTime));
        }
    }
}
