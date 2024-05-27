using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    private GameObject cameraObject;
    private Camera cameraComponent;
    private float bulletSpeedy = 2f; // 弾速。動く速さ

    private float bulletSpeedx;
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        cameraComponent = cameraObject.GetComponent<Camera>();
        bulletSpeedx = Random.Range(-1f, 1f); // 左右にばらつくようにする
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletSpeedx * Time.deltaTime, bulletSpeedy * Time.deltaTime, 0f);

        // 少しずつ減速する
        bulletSpeedx *= 0.99f;
        bulletSpeedy *= 0.99f;

        // 画面外に出たら消す
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0 ||
            viewPos.y > 1 ||
            viewPos.x < 0 ||
            viewPos.x > 1) // これ何とか短くならないかな)
        {
            Destroy(gameObject);
        }

        // 速度が一定以下になっても消す
        if (bulletSpeedy < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
