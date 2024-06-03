using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORBBulletController : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    public const float ATTACK = 1f;
    private Camera cameraComponent;

    public float attack { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        attack = 1f;
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed.x + CameraController.cameraSpeed.x) * Time.deltaTime, (speed.y + CameraController.cameraSpeed.y) * Time.deltaTime, 0f);

        // âÊñ äOÇ…èoÇΩÇÁè¡Ç∑
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0 ||
            viewPos.y > 1 ||
            viewPos.x < 0 ||
            viewPos.x > 1) // Ç±ÇÍâΩÇ∆Ç©íZÇ≠Ç»ÇÁÇ»Ç¢Ç©Ç»
        {
            Destroy(gameObject);
        }
    }
}
