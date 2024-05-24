using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speedx = 0.05f;
    private float speedy = 0.05f;

    // エディタでアタッチ
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject cameraObject;

    private Camera cameraComponent;
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = cameraObject.GetComponent<Camera>(); // カメラコンポーネント取得
    }

    // Update is called once per frame
    void Update()
    {
        // 移動！
        if (Input.GetKey(KeyCode.W))
        {
            Move(0f, speedy);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-speedx, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(0f, -speedy);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(speedx, 0f);
        }

        // スペースキーで弾を発射
        // 初回は強くて速いビームが出る
        // 長押ししていると広範囲に広がる炎が出る
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 自分の現在位置に弾のプレハブを召喚
            Instantiate(playerRapidBullet, transform.position, Quaternion.identity);
        }
    }

    private void Move(float x, float y) // 移動可能判定とかを詰め込んだ
    {

        // 自分の座標(+補正)がカメラから出ないように制限
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        // 移動後のx,yがビューポートの0～1におさまってたら動いてよい
        if (viewPos.x + x < 1.0f && viewPos.x + x > 0f)
        {
            transform.Translate(x, 0f, 0f);
        }
        if (viewPos.y + y < 1.0f && viewPos.y + y > 0f)
        {
            transform.Translate(0f, y, 0f);
        }

    }
}
