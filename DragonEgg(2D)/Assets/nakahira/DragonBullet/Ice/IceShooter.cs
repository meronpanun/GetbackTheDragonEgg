using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShooter : MonoBehaviour
{
    // リソースファイルからロード
    private GameObject iceBullet;

    private Vector3 instanceOffset = new Vector3(0, 1, 0); // 補正です。

    private int attack = 0;
    private float timer = 0; // いつもの
    private float iceBulletInterval = 0.2f; // 次の弾が生成される間隔
    private int bulletCount = 0; // 今何個の弾が出現しているか
    private int bulletAngle = 20; // 何度回転するか

    private void Start()
    {
        iceBullet = (GameObject)Resources.Load("IceBullet");

        // アタッチされているドラゴンが右か左かで
        // 弾を生成する向きを変える　
        if (gameObject.name == "ChildDragonRight")
        {
            bulletAngle *= -1;
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

            if (bulletCount > 3) return; // 指定以上なら生成しない

            if (timer > iceBulletInterval)
            {
                // インスタンス化
                GameObject instance = Instantiate(iceBullet, transform.position + instanceOffset, Quaternion.identity);

                // 軸をずらして回転したい時は、
                // 一回自分中心で回転させて
                // 置きたい場所にずらせばよろし　
                Quaternion angleAxis = Quaternion.AngleAxis(bulletAngle * bulletCount, Vector3.forward);

                instance.transform.rotation *= angleAxis;

                bulletCount++;
                timer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            // 離すと一斉に飛ぶ
            // 処理を弾自身に持たせている
            bulletCount = 0;
        }
    }
}
