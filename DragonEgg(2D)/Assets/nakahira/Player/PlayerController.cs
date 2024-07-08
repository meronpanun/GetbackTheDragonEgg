using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private TestDragonStatus playerStatus;

    private float speed = 1f;
    private Vector2 speedVec = Vector2.zero;
    private float hitPoint = 10;
    private int attack = 1;

    // エディタでアタッチ
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject playerFireBullet;

    private Camera cameraComponent;

    // ビューポートの補正を定義
    private float viewOffsetX = 0.3f;
    private float viewOffsetY = 0.1f;

    private const float fireInterval = 0.2f; // 発射するまでの長押し時間
    private const float srowFireRate = 0.1f; // 発射間隔
    private float fireTimer = -fireInterval; // 初期値はfireInterval分減らしておく

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // 口元から発射するための補正です。

    private Animator animator; // 自分のアニメーターコンポーネント
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // これで個人情報公開できるかな
        cameraComponent = Camera.main; // カメラコンポーネント取得
        animator = GetComponent<Animator>();
        SetStatusFromData();
    }

    private void SetStatusFromData()
    {
        // Staticクラスから自分のデータを取得
        // これはあくまでもテスト
        BattleTeam.sParentDragonData = new TestDragonStatus("0,10,1,3,4,5,6");
        playerStatus = BattleTeam.sParentDragonData;
        hitPoint = playerStatus.hp;
        speed = playerStatus.speed;
        attack = playerStatus.attack;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(blinking);

        // 移動！
        // キーを押すとその方向の内部的なベクトルが加算
        // それをもとに最後に移動
        if (Input.GetKeyDown(KeyCode.W))
        {
            speedVec += Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            speedVec += Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speedVec += Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            speedVec += Vector2.right;
        }
        // 長いけど許して
        if (Input.GetKeyUp(KeyCode.W))
        {
            speedVec -= Vector2.up;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            speedVec -= Vector2.left;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speedVec -= Vector2.down;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            speedVec -= Vector2.right;
        }
        //Debug.Log($"{speedVec}, {speed}");
        Move(speedVec, speed);

        // スペースキーで弾を発射
        // 初回は強くて速いビームが出る
        // 長押ししていると広範囲に広がる炎が出る
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 自分の現在位置に弾のプレハブを召喚
            GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
            // 自分の攻撃力を上乗せ
            bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
        }
        if (Input.GetKey(KeyCode.Space)) // Spaceキー長押しで
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > srowFireRate) // fireRate秒に一回炎が発射される
            {
                GameObject bullet = Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                // 自分の攻撃力を上乗せ
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                fireTimer = 0; // タイマーリセット
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) // キーを離したら
        {
            fireTimer = -fireInterval; // fireTimerの初期値をfireInterval分ずらしておく
        }
    }

    private void Move(Vector2 speedVec, float speed) // 移動可能判定とかを詰め込んだ
    {
        // まず単位ベクトル化
        Vector2 generalVec = speedVec.normalized;
        // 関数で複数回使う形を変数として宣言
        float speedX = generalVec.x * speed * Time.deltaTime;
        float speedY = generalVec.y * speed * Time.deltaTime;
        // 自分の座標がカメラから出ないように制限
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        // 移動後のx,yがビューポートの0～1におさまってたら動いてよい
        // 壁際でも沿う方向になら進める
        // でも正直なんでこれで動くのかよくわからない
        if (viewPos.x + viewOffsetX + (speedVec.x * 0.01f) < 1.0f && viewPos.x - viewOffsetX + (speedVec.x * 0.01f) > 0f)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.y + viewOffsetY + (speedVec.y * 0.01f) < 1.0f && viewPos.y - viewOffsetY + (speedVec.y * 0.01f) > 0f)
        {
            transform.Translate(0f, speedY, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 敵に当たったら
        {
            Damage(collision.GetComponent<Enemy>().attack);
        }
        else if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Damage(collision.GetComponent<ORBBulletController>().attack);
        }
    }

    private void Damage(int attack) // hitPointはここから減らすこと
    {
        DamageNumberGenerator.GenerateText(attack, transform.position, Color.red);
        hitPoint -= attack;
        if (hitPoint > 0) // 生きていたら
        {
            StartCoroutine(Blinking(4, 0.05f)); // 点滅
        }
        else // でなければ
        {
            animator.SetTrigger("Death"); // 脂肪モーションを再生
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
}
