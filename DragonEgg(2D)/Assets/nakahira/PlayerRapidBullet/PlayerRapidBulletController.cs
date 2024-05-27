using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : MonoBehaviour
{

    private GameObject cameraObject;
    private Camera cameraComponent;
    private float bulletSpeed = 10f; // íeë¨ÅBìÆÇ≠ë¨Ç≥
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        cameraComponent = cameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() // ê∂Ç‹ÇÍÇΩÇÁàÍíºê¸Ç…ècï˚å¸Ç…à⁄ìÆÇ∑ÇÈ
    {
        transform.Translate(0f, bulletSpeed * Time.deltaTime, 0f);

        // âÊñ äOÇ…èoÇΩÇÁè¡Ç∑
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
