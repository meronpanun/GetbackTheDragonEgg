using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float speedx = 0f;
    [SerializeField] private float speedy = -1f;

    private Camera cameraComponent;
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0f);

        // ‰æ–ÊŠO‚Éo‚½‚çÁ‚·
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
