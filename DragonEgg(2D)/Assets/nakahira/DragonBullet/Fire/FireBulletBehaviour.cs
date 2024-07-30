using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletBehaviour : MonoBehaviour
{
    // リソースファイルからロード
    private GameObject playerRapidBullet;
    private GameObject playerFireBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // 口元から発射するための補正です。

    private const float rapidFireInterVal = 0.3f; // 発射するまでの長押し時間
    private const float fireInterval = 0.4f; // 発射するまでの長押し時間
    private const float srowFireRate = 0.1f; // 発射間隔
    private float fireTimer = -fireInterval; // 初期値はfireInterval分減らしておく

    private int attack = 0;

    private Coroutine coroutine = null;

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
        // スペースキーで弾を発射。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // 初回にも短いタメを設ける
            coroutine = StartCoroutine(RapidFireCharge());
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
            // コルーチン中断
            //Debug.Log("中断");
            StopCoroutine(coroutine);
            fireTimer = -fireInterval; // fireTimerの初期値をfireInterval分ずらしておく
        }
    }

    IEnumerator RapidFireCharge()
    {
        // 指定秒数待ってからインスタンス
        yield return new WaitForSeconds(rapidFireInterVal);

        // 自分の現在位置に弾のプレハブを召喚
        GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
        // 自分の攻撃力を上乗せ
        bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
    }
}
