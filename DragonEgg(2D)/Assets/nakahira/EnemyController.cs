using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speedx = 0.1f;
    [SerializeField] private float speedy = 0f;

    public float cycleSpeed = 5f; // 大きくすれば速度が小さくなります  // バグのため実装できません。
    public float radius = 5f; // 大きくすれば半径が小さくなります

    private float myTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        speedx = (float)Math.Cos(myTime * 5) / 5;

        transform.Translate(speedx, speedy, 0f);
    }
}
