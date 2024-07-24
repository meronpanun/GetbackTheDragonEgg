using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private TestDragonStatus playerStatus;

    private float speed = 1f;
    //private Vector2 speedVec = Vector2.zero;
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
        //左スティック
        Vector2 speedVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
 
        Debug.Log("H" + Input.GetAxis("Horizontal"));
        Debug.Log("V" + Input.GetAxis("Vertical"));

        //Debug.Log($"{speedVec}, {fadeSpeed}");
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

        // コントローラー
        if (Input.GetKeyDown("joystick button 0")) // A(仮)ボタンでビーム
        {
            // 自分の現在位置に弾のプレハブを召喚
            GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
            // 自分の攻撃力を上乗せ
            bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
        }
        if (Input.GetKey("joystick button 0")) // A(仮)ボタン長押しで
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

        if (Input.GetKeyUp("joystick button 0")) // ボタンを離したら
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

        transform.Translate(speedX, speedY, 0f);

        // 越えたら戻す
        if (viewPos.x + viewOffsetX > 1.0f)
        {
            transform.position = new Vector3(transform.position .x, transform.position.y, 0f);
        }
        if (viewPos.x - viewOffsetX < 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        if (viewPos.y + viewOffsetY > 1.0f)
        {
            transform.position = new Vector3(0f, transform.position.y, 0f);

        }
        if (viewPos.y - viewOffsetY < 0f)
        {
            transform.position = new Vector3(0f, transform.position.y, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.CompareTag("Enemy") || temp.CompareTag("Boss")) // 敵に当たったら
        {
            Damage(collision.GetComponent<Enemy>().attack);
        }
        else if (temp.CompareTag("EnemyBullet"))
        {
            Damage(collision.GetComponent<EnemyBullet>().attack);
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
