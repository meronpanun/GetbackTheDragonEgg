using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShooter : MonoBehaviour
{
    // リソースファイルからロード
    private GameObject windBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.2f, 0); // 口元から発射するための補正です。

    private int attack = 0;

    private void Start()
    {
        windBullet = (GameObject)Resources.Load("WindBullet");

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
            //　仮で単押しで一回弾を出す
            Instantiate(windBullet, transform.position + instanceOffset, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
        }
    }
}
