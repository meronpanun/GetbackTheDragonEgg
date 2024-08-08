using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : PlayerBullet
{
    private const int FIREATTACK = 1; // この値にドラゴンの攻撃力を掛けるつもり
    // エディタで
    // Resourceは見通しが悪くなる
    public AudioClip audioClip;
    private void Awake()
    {
        baseAttack = FIREATTACK;
    }

    protected override void Start()
    {
        base.Start();
        bulletSpeedx = Random.Range(-1f, 1f); // ばらつかせる
        // その場に音を鳴らす
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // 少しずつ減速する
        bulletSpeedx *= 0.99f;
        bulletSpeedy *= 0.99f;

        // 速度が一定以下になっても消す
        if (bulletSpeedy < 0.8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 敵に当たったら消える
        GameObject g = collision.gameObject;
        if (g.CompareTag("Enemy") ||
            g.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
