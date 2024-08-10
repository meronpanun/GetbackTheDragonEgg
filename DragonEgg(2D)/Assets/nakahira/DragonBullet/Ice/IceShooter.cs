using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShooter : MonoBehaviour
{
    // リソースファイルからロード
    private GameObject iceBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // 補正です。

    private int attack = 0;
    private float timer = 0; // いつもの
    private float iceBulletInterval = 0.2f; // 次の弾が生成される間隔
    private int bulletCount = 0; // 今何個の弾が出現しているか
    private int bulletAngle = 30; // 何度回転するか
    private int angleOffset = 0; // その名の通り
    private const int maxBulletCount = 7; // 最大何個出現させられるか
    // ここで悲報です
    // 途中から定数をロワーキャメルケースで書いてました
    // 今更変えないけど　

    private void Start()
    {
        iceBullet = (GameObject)Resources.Load("IceBullet");

        // アタッチされているドラゴンが右か左かで
        // 弾を生成する向きを変える　
        if (gameObject.name == "ChildDragonRight")
        {
            bulletAngle *= -1;
            angleOffset *= -1;
        }

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
            // 何もなし
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            // 長押ししていると弾が次々に生成
            timer += Time.deltaTime;

            if (bulletCount >= maxBulletCount) return; // 指定以上なら生成しない

            if (timer > iceBulletInterval)
            {
                // 回転を生成
                Quaternion bulletRotation = Quaternion.AngleAxis(bulletAngle * bulletCount + angleOffset, Vector3.forward);

                // インスタンス化 親は自分にして、追尾させる
                GameObject instance = Instantiate(iceBullet, 
                    transform.position, 
                    bulletRotation ,
                    transform);

                // 軸をずらして回転したい時は、
                // 一回自分中心で回転させてから
                // そのあと置きたい場所にずらせばよろし　
                instance.transform.position += bulletRotation * instanceOffset;

                bulletCount++;
                timer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            // 移動する処理は弾自身に持たせている
            // 弾の数もリセット
            bulletCount = 0;
            timer = 0;
        }
    }
}
