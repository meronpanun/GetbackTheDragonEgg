using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private float speed = 1f;
    private int hitPoint = 10;

    private Camera cameraComponent;

    // ビューポートの補正を定義
    private float viewOffsetRight = 0.38f;
    private float viewOffset = 0.1f;

    private Animator animator; // 自分のアニメーターコンポーネント

    [SerializeField] // Resourseファイルがゴミ屋敷になりそうなのでアウトレット接続
    private AudioClip audioClip;

    private GameObject fadePanel;

    public static int playerAttack; // 攻撃力

    private TextMeshProUGUI hpText;

    private Shooter playerShooter;
    private GameObject rightShooter;
    private GameObject leftShooter;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // これで個人情報公開できるかな
        cameraComponent = Camera.main; // カメラコンポーネント取得
        animator = GetComponent<Animator>();
        SetStatusFromData();
        fadePanel = GameObject.Find("FadePanel");
        hpText = GameObject.Find("HP").GetComponent<TextMeshProUGUI>();
        hpText.text = hitPoint.ToString(); // スクリプト操作だとNullるから直接操作しかないってマ?
        // 
        playerShooter = GetComponent<Shooter>();
        leftShooter = transform.GetChild(0).gameObject;
        // ここ最初にShooterを取得する感じだったけど
        // なぜか取得できなかったので死んだときに取得する
        rightShooter = transform.GetChild(1).gameObject;
    }

    private void SetStatusFromData()
    {
        // 現在のステージクリア状況を記録している"Progress"から
        // 今のステータスを決める
        int saveData = PlayerPrefs.GetInt("Progress", 0);　
        switch (saveData)
        {
            case 0:
                hitPoint = 50; // リテラルパンチ
                speed = 2;
                playerAttack = 1;
                break;
            case 1:
                hitPoint = 75;
                speed = 3;
                playerAttack = 3;
                break;
            case 2:
                hitPoint = 100;
                speed = 3;
                playerAttack = 6;
                break;
            case 3:
                hitPoint = 125;
                speed = 3.5f;
                playerAttack = 10;
                break;
            case 4:
                hitPoint = 150;
                speed = 4;
                playerAttack = 12;
                break;
            default:
                hitPoint = 999;
                speed = 8;
                playerAttack = 114514;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //左スティック
        Vector2 speedVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Debug.Log("H" + Input.GetAxis("Horizontal"));
        //Debug.Log("V" + Input.GetAxis("Vertical"));

        //Debug.Log($"{speedVec}, {fadeSpeed}");

        if (hitPoint <= 0) // 死んだら
        {
            // カメラに取り残される感じで親解除
            transform.parent = null;
        }
        else
        {
            Move(speedVec, speed);
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

        // 越えたら進めない
        // 右方向にはUIがあるので追加で補正する
        if (viewPos.x + viewOffsetRight < 1.0f && speedX > 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.x - viewOffset > 0f && speedX < 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.y + viewOffset < 1.0f && speedY > 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
        if (viewPos.y - viewOffset > 0f && speedY < 0)
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
        GameAudio.InstantiateSE(audioClip);

        DamageNumberGenerator.GenerateText(attack, transform.position, Color.red);
        hitPoint -= attack;
        if (hitPoint > 0) // 生きていたら
        {
            StartCoroutine(Blinking(4, 0.05f)); // 点滅
            hpText.text = hitPoint.ToString(); // HPの減少を反映
        }
        else // でなければ
        {
            animator.SetTrigger("Death"); // 脂肪モーションを再生
            hpText.text = "0";
            // プレイヤーとコドモドラゴンについているコンポーネントを取得して
            // 弾を撃たせないようにしたい
            playerShooter.SetCanShoot(false);
            if (rightShooter.GetComponent<Shooter>() != null) rightShooter.GetComponent<Shooter>().SetCanShoot(false);
            if (leftShooter.GetComponent<Shooter>() != null) leftShooter.GetComponent<Shooter>().SetCanShoot(false);
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

    // 死亡時の処理 アニメーションで実行している
    public void Death()
    {
        fadePanel.GetComponent<FadeManager>().FadeOutSwitch(12);
    }
}
