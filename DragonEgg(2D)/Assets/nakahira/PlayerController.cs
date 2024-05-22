using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speedx = 0.1f;
    private float speedy = 0.1f;

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
        // 自分の座標がカメラから出ないように制限
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        Debug.Log(viewPos);
        // x,yがビューポートの0～1におさまってたら動いてよい
        if (viewPos.x < 1.0f && viewPos.x > 0f ||
            viewPos.y < 1.0f && viewPos.y > 0f)
        {
            transform.Translate(x, y, 0f);
        }

    }
}
