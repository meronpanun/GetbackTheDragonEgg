using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speedx = 0;
    protected float speedy = 0;

    protected Animator animator;
    protected Camera cameraComponent;

    private static bool s_dontGetPlayer = true; // 一番最初、一回だけplayerを取得するためのフラグ

    protected float hitPoint = 1; // 体力！
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (OffScreenJudgment()) // 画面外にでたら
        {
            Destroy(gameObject);
        }
    }

    protected bool OffScreenJudgment() // 画面内ならtrue、外ならfalse
    {
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        return (viewPos.y < 0 ||
                viewPos.y > 1 ||
                viewPos.x < 0 ||
                viewPos.x > 1); // これ短くならないかな
    }

    protected void DestroyThisGameobject() // アニメーションイベントに献上するやつ
    {
        Destroy(gameObject);
    }

    protected Vector2 UnitVector(GameObject gameObject) // この敵から引数のオブジェクトへの単位ベクトルを生成します。
    {
        Vector3 relativeDistance = gameObject.transform.position - transform.position;
        return relativeDistance.normalized;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Damage(collision.gameObject.GetComponent<PlayerBullet>().attack);
        }
    }

    protected void Damage(float attack) // hitPointはここから減らすこと
    {
        hitPoint -= attack;
        if (hitPoint <= 0)
        {
            animator.SetTrigger("Death"); // 継承したオブジェクトには必ずDeathをつけること
        }
    }
}
