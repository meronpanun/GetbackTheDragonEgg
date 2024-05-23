using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speedx = 0.1f;
    [SerializeField] private float speedy = 0f;

    private double myTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        speedx = Math.Sin(myTime);

        transform.Translate();
    }
}
