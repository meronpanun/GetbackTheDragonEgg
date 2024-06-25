using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORBBulletController : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    public const int ATTACK = 1;
    private Camera cameraComponent;

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
        transform.Translate((speed.x + BattleCameraController.cameraSpeed.x) * Time.deltaTime, (speed.y + BattleCameraController.cameraSpeed.y) * Time.deltaTime, 0f);

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
