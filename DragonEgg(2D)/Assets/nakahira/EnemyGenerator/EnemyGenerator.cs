using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // エディタでアタッチ
    public GameObject prefab;
    Camera mainCamera;

    // エディタでいろいろできるようにしたかった。

    private float offsetX = 0.1f;
    private float offsetY = 0.1f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // FixedUpdateで処理の軽減を図ります
    private void FixedUpdate()
    {
        if (CheckInCamera())
        {
            // 自身の場所にアタッチされたゲームオブジェクトをショウカン
            Instantiate(prefab, transform.position, Quaternion.identity);

            // 自分は退場
            Destroy(gameObject);
        }
    }

    private bool CheckInCamera()
    {
        // 現在位置を割り出してカメラに入ったかを返す
        Vector2 viewPort = mainCamera.WorldToViewportPoint(transform.position);
        bool result = (viewPort.x + offsetX) > 0 &&
                      (viewPort.x - offsetX) < 1 &&
                      (viewPort.y + offsetY) > 0 &&
                      (viewPort.y - offsetY) < 1;
        return result;
    }
}
