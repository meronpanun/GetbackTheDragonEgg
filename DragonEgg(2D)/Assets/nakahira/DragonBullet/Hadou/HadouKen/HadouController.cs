using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouController : PlayerBullet
{
    private const int HADOUKENATTACK = 2;
    [SerializeField]
    private AudioClip se;
    private void Awake()
    {
        baseAttack = HADOUKENATTACK;
    }
    protected override void Start()
    {
        base.Start();
        GameAudio.InstantiateSE(se);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // ìGÇ…ìñÇΩÇ¡ÇΩÇÁè¡Ç¶ÇÈ
        GameObject g = collision.gameObject;
        if (g.CompareTag("Enemy") ||
            g.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
