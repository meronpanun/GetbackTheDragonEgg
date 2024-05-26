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
    private float shootSpan = 1; // 何秒おきに弾を発射するか

    private bool canMove = true; // 動けるか
    private bool canShoot = true;  // 弾撃てるか

    private Animator animator;
    private Camera cameraComponent;
     //プレハブなのでエディタからよろしく
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (canMove) // 動く関連の処理
        {
            speedx = (float)Math.Cos(angle * cycleSpeed) * Time.deltaTime * moveSpeed;
            transform.Translate(speedx, speedy, 0f);
        }

        if (canShoot)
        {
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }

        // 画面外に出たら消す
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }

    private async Task OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("通貨");
        if (collision.gameObject.tag == "PlayerBullet")
        {
            canMove = false;
            canShoot = false;
            animator.SetTrigger("Death"); // 死亡モーションを再生
            await Task.Delay(TimeSpan.FromSeconds(0.5f));// モーション終了(0.5秒固定、毎回編集しようね)まで待つ
            Destroy(gameObject);
        }
    }
}
