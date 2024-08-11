using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Vector2 speed = Vector2.zero;

    protected Animator animator;
    protected Camera cameraComponent;

    protected float hitPoint = 1; // 体力！

    protected bool canMove = true; // 動けるか
    protected bool canShoot = true;  // 弾撃てるか

    public int attack { get; protected set; }

    protected float shootSpan = 0; // 何秒おきに球を撃つか(canShootがfalseの時は関係ない)
    protected float shootTimer = 0; // 計測する変数

    protected AudioClip deathSound; // 敵が消滅するときの音は今回固定にしよう

    protected float invincibleTime = 0.2f; // 無敵時間記録用
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
        // リソースファイルから取る
        deathSound = (AudioClip)Resources.Load("EnemyDeathSound");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // 無敵時間の減算をここで
        if (invincibleTime > 0)
        {
            invincibleTime -= Time.deltaTime;
        }
        else
        {
            invincibleTime = 0;
        }

        if (canMove)
        {
            Move();
        }
        if (canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                Shoot();
            }
        }

        // 画面外に出たら
        if (OffScreenJudgment(0.2f))
        {
            // 消す
            Destroy(gameObject);
        }
    }

    protected bool OffScreenJudgment(float offset) // 画面内ならtrue、外ならfalse
    {
        // offsetは外側方向に広げるように働く
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        return (viewPos.y + offset < 0 ||
                   viewPos.y - offset > 1 ||
                   viewPos.x + offset < 0 ||
                   viewPos.x - offset > 1); // これ短くならないかな
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 無敵時間中なら早期riturn
        if (invincibleTime > 0) return;

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            //Debug.Log(collision);
            Damage(collision.gameObject.GetComponent<PlayerBullet>().finalAttack);
            // 無敵にする
            Invincible(0.33f);
            return;
        }

        // ボスならこの先は実行しない
        if (gameObject.CompareTag("Boss")) return;

        // もしプレイヤーに衝突したら
        if (collision.gameObject.CompareTag("Player"))
        {
            // 死
            OnDeath();
            return;
        }
    }

    protected void Damage(int attack) // hitPointはここから減らすこと
    {
        DamageNumberGenerator.GenerateText(attack, transform.position, Color.white);
        hitPoint -= attack;
        if (hitPoint <= 0)
        {
            OnDeath();
        }
    }

    protected virtual void Move() // 移動関連の処理はここに書きましょう
    {
        // カメラの移動にあわせて動いておく
        // これで派生クラスはカメラの移動を意識せずに実装できる

        // ちょっと条件分岐をかませて
        // tagがbossだったら移動しない
        if (gameObject.CompareTag("Boss")) return;
        transform.Translate(BattleCameraController.cameraSpeed * Time.deltaTime, Space.World);
    }
    protected virtual void Shoot() // 弾撃つ関連の処理はここに書きましょう
    {

    }

    protected virtual void OnDeath() // 自作のOnメソッドです。Hpが0になったときに実行されます。
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        animator.SetTrigger("Death"); // 継承したオブジェクトには必ずDeathをつけること
    }

    // その名の通り引数の向きに球を打つ処理のセットです。
    // 使用機会が多かったので関数化
    // angleは単位ベクトルにしないと速さが変わっちゃうよ
    protected void InstantiateBulletToAngle(GameObject bullet, Vector2 angle)
    {
        // 生成。向きはangleの向き。
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.down, angle));
        // 移動方向は別で設定する。
        bulletInstance.GetComponent<EnemyBullet>().SetAngle(angle);
    }

    // 無敵時間を付与できる関数
    public void Invincible(float time)
    {
        invincibleTime += time;
    }
}
