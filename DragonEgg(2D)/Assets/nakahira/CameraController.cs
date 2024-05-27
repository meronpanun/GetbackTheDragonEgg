using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float cameraSpeedy = 0.5f; // カメラの縦の移動スピード
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, cameraSpeedy * Time.deltaTime, 0f);
    }
}
