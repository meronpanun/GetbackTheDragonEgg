using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORBBulletController : MonoBehaviour
{
    private float speed = 1f;
    public const int ATTACK = 1;
    private Camera cameraComponent;
    // インスタンス側で代入してもらう
    public Vector2 angle;
    public int attack { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        attack = 1;
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //　カメラの移動速度含めて移動
        transform.Translate((angle * speed + BattleCameraController.cameraSpeed) * Time.deltaTime);

        // 画面外に出たら消す
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0 ||
            viewPos.y > 1 ||
            viewPos.x < 0 ||
            viewPos.x > 1) // これ何とか短くならないかな
        {
            Destroy(gameObject);
        }
    }
}
