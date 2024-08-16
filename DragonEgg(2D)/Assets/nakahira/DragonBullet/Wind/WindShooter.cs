using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShooter : Shooter
{
    // リソースファイルからロード
    private GameObject windBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.2f, 0); // 口元から発射するための補正です。

    private bool isStraight = true; // まっすぐ打つか横に打つか(グラディウスのDouble)

    private const int angleRangeMax = 11;
    private const int angleRangeMin = -10;

    private int leftOrRight = 1;

    PlayerChargeMeterController meter;

    private void Start()
    {
        windBullet = (GameObject)Resources.Load("WindBullet");
        // 左右で横に発射する弾の向きを逆にしなければ
        // あとゲージも
        if (name == "ChildDragonRight")
        {
            leftOrRight = -1;
            meter = GameObject.Find("RightChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
        else
        {
            meter = GameObject.Find("LeftChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
    }

    void Update()
    {
        if (!canShoot) return;
        // スペースキーで弾を発射。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {

            // 単押しで一回弾を出す
            if (isStraight)
            {
                // 角度ランダム
                Quaternion angle = Quaternion.AngleAxis(Random.Range(angleRangeMin, angleRangeMax), Vector3.forward);
                // trueなら前に撃つ
                Instantiate(windBullet, transform.position + angle * instanceOffset, angle);
                isStraight = false;
                // ゲージをスイッチ
                meter.FillMeter(1);
            }
            else
            {
                // 角度をランダムにする
                Quaternion angle = Quaternion.AngleAxis(Random.Range(80 * leftOrRight, 101 * leftOrRight), Vector3.forward);
                // falseなら横にも出すか
                Instantiate(windBullet, transform.position + angle * instanceOffset, angle);
                isStraight = true;
                // ゲージをスイッチ
                meter.FillMeter(0);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            // 無し
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            // 無し
        }

        // ゲージ変動がないのでここも空白
    }
}
