using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// こいつはトリガー内にプレイヤーの攻撃が入ってきたら
// 親オブジェクトに知らせます。
// クールタイムあり。　

public class DF_ApproachObserver : MonoBehaviour
{
    // 親のオブジェクト
    private GameObject dragonFry;
    private DragonFryController dragonFryController;
    // 一度回避したら何秒のクールタイムに入るか
    private const float coolTime = 1f;
    // 記録用タイマー
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        // 取得
        dragonFry = transform.parent.gameObject;
        dragonFryController = dragonFry.GetComponent<DragonFryController>();
    }

    // Update is called once per frame
    void Update()
    {
        // OnTriggerEnter2Dで使います。
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("呼ばれてます");
        // クールタイム中なら無効
        if (timer < coolTime) return;

        // 一文字にしちゃう
        GameObject g = collision.gameObject;
        if (g.CompareTag("Player") || g.CompareTag("PlayerBullet"))
        {
            // よけろ！！
            //Debug.Log("よけろ！");
            dragonFryController.Dodge();
            timer = 0;
        }
    }
}
