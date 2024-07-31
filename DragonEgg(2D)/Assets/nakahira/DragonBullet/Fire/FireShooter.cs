using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShooter : MonoBehaviour
{
    // リソースファイルからロード
    private GameObject playerRapidBullet;
    private GameObject playerFireBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // 口元から発射するための補正です。

    private const float rapidFireCooldown = 0.5f; // クールタイム
    private float rapidFireTimer = rapidFireCooldown; // 最初は撃てる
    private const float fireInterval = 0.1f; // 発射するまでの長押し時間
    private const float srowFireRate = 0.1f; // 発射間隔
    private float fireTimer = -fireInterval; // 初期値はfireInterval分減らしておく

    private int attack = 0;

    private void Start()
    {
        playerFireBullet = (GameObject)Resources.Load("PlayerFire");
        playerRapidBullet = (GameObject)Resources.Load("PlayerRapidBullet");

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
        // タイマー加算
        rapidFireTimer += Time.deltaTime;

        // スペースキーで弾を発射。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // 速射弾のクールタイムを超えていれば
            if (rapidFireTimer > rapidFireCooldown)
            {
                // 自分の現在位置に弾のプレハブを召喚
                GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
                // 自分の攻撃力を上乗せ
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                // クールタイムを課す
                rapidFireTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            fireTimer += Time.deltaTime;

            if (fireTimer > srowFireRate) // fireRate秒に一回炎が発射される
            {
                GameObject bullet = Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                // 自分の攻撃力を上乗せ
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                fireTimer = 0; // タイマーリセット
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            fireTimer = -fireInterval; // fireTimerの初期値をfireInterval分ずらしておく
        }
    }
}
