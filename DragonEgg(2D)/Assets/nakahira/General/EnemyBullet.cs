using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    protected Camera cameraComponent;
    // インスタンス側で代入してもらう
    protected Vector2 angle;
    protected float speed;

    public int attack { get; protected set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //　カメラの移動速度含めて移動
        transform.Translate((angle * speed + BattleCameraController.cameraSpeed) * Time.deltaTime);

        // 画面外に出たら消す
        if (CheckViewPosOver())
        {
            Destroy(gameObject);
        }
    }

    protected bool CheckViewPosOver()
    {
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        return (viewPos.y < 0 ||
                viewPos.y > 1 ||
                viewPos.x < 0 ||
                viewPos.x > 1); // これ何とか短くならないかな
    }

    public void SetAngle(Vector2 _angle)
    { 
        angle = _angle; 
    }
}
