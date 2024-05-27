using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORBBulletController : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;

    private float speedyOffset = 0.5f;

    private Camera cameraComponent;
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed.x * Time.deltaTime, (speed.y + speedyOffset) * Time.deltaTime, 0f);

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
