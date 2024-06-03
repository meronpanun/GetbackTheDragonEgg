using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speedx = 0;
    protected float speedy = 0;

    protected Animator animator;
    protected Camera cameraComponent;

    protected float hitPoint = 1; // 体力！

    protected GameObject prefabStore;

    protected bool canMove = true; // 動けるか
    protected bool canShoot = true;  // 弾撃てるか

    public float attack { get; protected set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        prefabStore = GameObject.Find("PrefabStore");
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (canMove)
        {
            Move();
        }
        if (canShoot)
        {
            Shoot();
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
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Damage(collision.gameObject.GetComponent<PlayerBullet>().attack);
        }
    }

    protected void Damage(float attack) // hitPointはここから減らすこと
    {
        DamageNumberGenerator.GenerateText(attack, transform.position, Color.white);
        hitPoint -= attack;
        if (hitPoint <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false; // 当たり判定を消す
            animator.SetTrigger("Death"); // 継承したオブジェクトには必ずDeathをつけること
        }
    }

    protected virtual void Move() // 移動関連の処理はここに書きましょう
    {
        
    }
    protected virtual void Shoot() // 弾撃つ関連の処理はここに書きましょう
    {

    }
}
