using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletBehaviour : MonoBehaviour, IDragonBullet
{ 
    // リソースファイルでアタッチ
    private GameObject playerRapidBullet;
    private GameObject playerFireBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // 口元から発射するための補正です。

    private const float fireInterval = 0.2f; // 発射するまでの長押し時間
    private const float srowFireRate = 0.1f; // 発射間隔
    private float fireTimer = -fireInterval; // 初期値はfireInterval分減らしておく

    private void Start()
    {
        playerFireBullet = (GameObject)Resources.Load("PlayerFire");
        playerRapidBullet = (GameObject)Resources.Load("PlayerRapidBullet");
    }

    public void GetKeyDownBehaviour(int attack)
    {
        // 初回は強くて速いビームが出る
        // 長押ししていると広範囲に広がる炎が出る
        // 自分の現在位置に弾のプレハブを召喚
        GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
        // 自分の攻撃力を上乗せ
        bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
    }

    public void GetKeyBehaviour(int attack)
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

    public void GetKeyUpBehaviour(int attack)
    {
        fireTimer = -fireInterval; // fireTimerの初期値をfireInterval分ずらしておく
    }
}
