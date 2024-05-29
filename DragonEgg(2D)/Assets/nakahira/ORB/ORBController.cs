using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class ORBController : MonoBehaviour
{
    public float speedx = 0f;
    public float speedy = 0f;

    public float cycleSpeed = 5f; // 大きくすれば回転周期が小さくなり、より早く往復します。
    public float moveSpeed = 5f; // 大きくすればより早く移動し、半径が大きくなります。

    private float angle; // 角度の計算に使うタイマー
    private float shootTimer; // 弾の発射を制御するタイマー
    private float shootSpan = 2; // 何秒おきに弾を発射するか

    private bool canMove = true; // 動けるか
    private bool canShoot = true;  // 弾撃てるか

    private Animator animator;
    private Camera cameraComponent;
    private GameObject player;
     //プレハブなのでエディタからよろしく
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (canMove) // 動く関連の処理
        {
            speedx = (float)Math.Cos(angle * cycleSpeed) * moveSpeed;
            transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0f);
        }

        if (canShoot)
        {
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                // プレイヤーに向けて球を撃つ処理
                Vector3 relativeDistance = player.transform.position - transform.position;
                GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletInstance.GetComponent<ORBBulletController>().speed = relativeDistance.normalized; // Vector2にVector3ぶち込んで大丈夫かなあ
            }
        }

        // 画面外に出たら消す
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //canMove = false;
            canShoot = false;
            animator.SetTrigger("Death"); // 死亡モーションを再生。終了したらDestroy
        }
    }

    private void DestroyThisGameobject() // アニメーションイベントに献上するやつ
    {
        Destroy(gameObject);
    }
}
