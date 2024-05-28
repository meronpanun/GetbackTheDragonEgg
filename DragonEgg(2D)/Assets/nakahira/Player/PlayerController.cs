using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speedx = 1f;
    private float speedy = 1f;

    // エディタでアタッチ
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject playerFireBullet;

    private Camera cameraComponent;

    private int hitPoint = 10;

    private float rapidFireWait = 0;
    private float fireInterval = 0.2f; // 発射するまでの長押し時間
    private float fireTimer = 0;
    private float srowFireRate = 0.1f; // 発射間隔

    private Vector3 instanceOffset = new Vector3(0, 0.15f, 0); // 口元から発射するための補正です。
    // Start is called before the first frame update
    void Start()
    {
        fireTimer -= fireInterval; // 最初の一回だけ許して
        cameraComponent = Camera.main; // カメラコンポーネント取得
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(blinking);

        // 移動！
        if (Input.GetKey(KeyCode.W))
        {
            Move(0f, speedy * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-speedx * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(0f, -speedy * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(speedx * Time.deltaTime, 0f);
        }

        // スペースキーで弾を発射
        // 初回は強くて速いビームが出る
        // 長押ししていると広範囲に広がる炎が出る
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rapidFireWait <= 0) // もし打てる状況なら
            {
                // 自分の現在位置に弾のプレハブを召喚
                Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
                StartCoroutine(RapidFireSetWait(0.5f)); // クールタイムを設ける
            }
        }
        if (Input.GetKey(KeyCode.Space)) // Spaceキー長押しで
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > srowFireRate) // fireRate秒に一回炎が発射される
            {
                Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                fireTimer = 0; // タイマーリセット
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) // キーを離したら
        {
            fireTimer = -fireInterval; // fireTimerの初期値をfireInterval分ずらしておく
            StartCoroutine(RapidFireSetWait(0.5f)); // この後すぐにRapidFireを撃つのは許さん
        }
    }

    private void Move(float x, float y) // 移動可能判定とかを詰め込んだ
    {
        // 自分の座標がカメラから出ないように制限
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        // 移動後のx,yがビューポートの0～1におさまってたら動いてよい
        // 壁際でも沿う方向になら進める
        if (viewPos.x + x < 1.0f && viewPos.x + x > 0f)
        {
            transform.Translate(x, 0f, 0f);
        }
        if (viewPos.y + y < 1.0f && viewPos.y + y > 0f)
        {
            transform.Translate(0f, y, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "PlayerBullet") // 自分の弾以外に当たったら
        {
            hitPoint--;
            if (hitPoint > 0) // 生きていたら点滅させる
            {
                StartCoroutine(Blinking(4, 0.05f));
            }
            else
            {
                Destroy(gameObject); // 仮
                // HPがゼロになったら死亡アニメーションを再生してリトライ画面なりなんなり
            }
        }
    }

    IEnumerator Blinking(int count, float interval) // intervalは秒単位
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color visibleColor = new Color(255, 255, 255, 255);
        Color invisibleColor = new Color(255, 255, 255, 0);
        for (int i = 0; i < count; i++) // count回繰り返す
        {
            spriteRenderer.color = invisibleColor;
            yield return new WaitForSeconds(interval); // interval秒待つ
            spriteRenderer.color = visibleColor;
            yield return new WaitForSeconds(interval); // こんなもんで　どうでしょう
        }
    }

    IEnumerator RapidFireSetWait(float count) // count秒の待ち時間を付与します。
    {
        rapidFireWait = count;
        while (rapidFireWait > 0)
        {
            rapidFireWait -= Time.deltaTime;
            yield return null;
        }
    }
}
