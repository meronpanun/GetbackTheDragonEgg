using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : MonoBehaviour
{
    // エディタでアタッチ
    private GameObject cameraObject;
    private Camera cameraComponent;
    private float bulletSpeed = 10f; // 弾速。動く速さ
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        cameraComponent = cameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() // 生まれたら一直線に縦方向に移動する
    {
        transform.Translate(0f, bulletSpeed * Time.deltaTime, 0f);

        // 画面外に出たら消す
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
