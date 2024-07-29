using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private TestDragonStatus playerStatus;

    private IDragonBullet dragonBullet;

    private float speed = 1f;
    private float hitPoint = 10;
    private int attack = 1;

    private Camera cameraComponent;

    // ビューポートの補正を定義
    private float viewOffsetX = 0.3f;
    private float viewOffsetY = 0.1f;

    private Animator animator; // 自分のアニメーターコンポーネント
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // これで個人情報公開できるかな
        cameraComponent = Camera.main; // カメラコンポーネント取得
        animator = GetComponent<Animator>();
        SetStatusFromData();
        // 自分の種族に応じて出る弾を設定する
        // 今はテストで炎
        dragonBullet = gameObject.AddComponent<FireBullet>();
    }

    private void SetStatusFromData()
    {
        // Staticクラスから自分のデータを取得
        // これはあくまでもテスト
        BattleTeam.sParentDragonData = DragonRace.races.thunder;
        playerStatus = new TestDragonStatus("2,2,2,2,2,2,2");
        hitPoint = playerStatus.hp;
        speed = playerStatus.speed;
        attack = playerStatus.attack;
    }

    // Update is called once per frame
    void Update()
    {
        //左スティック
        Vector2 speedVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
 
        //Debug.Log("H" + Input.GetAxis("Horizontal"));
        //Debug.Log("V" + Input.GetAxis("Vertical"));

        //Debug.Log($"{speedVec}, {fadeSpeed}");
        Move(speedVec, speed);

        // スペースキーで弾を発射
        // その時の処理は別スクリプトにゆだねて付け替え可能にしてます。　
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            dragonBullet.GetKeyDownBehaviour(attack);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Spaceキー長押しで
        {
            dragonBullet.GetKeyBehaviour(attack);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // キーを離したら
        {
            dragonBullet.GetKeyUpBehaviour(attack);
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

        // 越えたら戻す
        if (viewPos.x + viewOffsetX < 1.0f && speedX > 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.x - viewOffsetX > 0f && speedX < 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.y + viewOffsetY < 1.0f && speedY > 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
        if (viewPos.y - viewOffsetY > 0f && speedY < 0)
        {
            transform.Translate(0f, speedY, 0f);
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
