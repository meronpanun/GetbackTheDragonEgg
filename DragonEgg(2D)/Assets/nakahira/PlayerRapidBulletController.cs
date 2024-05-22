using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : MonoBehaviour
{
    [SerializeField] Dragon dragon;

    int i;

    private float bulletSpeed = 1f; // 弾速。動く速さ
    // Start is called before the first frame update
    void Start()
    {
        i = dragon.num_a;
        Debug.Log(i);
    }

    // Update is called once per frame
    void Update() // 生まれたら一直線に縦方向に移動する
    {
        transform.Translate(0f, bulletSpeed, 0f);
    }
}
