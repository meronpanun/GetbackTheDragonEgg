using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletController : PlayerBullet
{
    private bool isStay = true; // 最初は待機

    protected override void Update()
    {
        // キーを離したら
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isStay = false;
        }

        if (isStay)
        {
            // おとなしくする
        }
        else
        {
            base.Update(); // いつもの動きをする
        }
    }

    public void  SetAttack(int attack)
    {
        finalAttack = attack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
