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
        // 移動！ 後ろに下がるときは少し遅い
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, speedy, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedx, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -speedy / 2, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedx, 0f, 0f);
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

    private void Move(Vector2 speed) // 移動可能判定とかを詰め込んだ
    {
        //cameraComponent.orthographicSize
        //if 
        //transform.Translate(speed);
    }
}
