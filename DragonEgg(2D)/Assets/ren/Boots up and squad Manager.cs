using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class BootsupandsquadManager : MonoBehaviour
{
    private Vector2 tmp;
    GameObject powerUpCanvas;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GameObject.Find("Main Camera").transform.position;
        powerUpCanvas = GameObject.Find("PowerUpCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        float x = tmp.x;
        float y = tmp.y;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(tmp.x -80, tmp.y);
        }

        //if (x <= -80 && y <= 0)
        //{
        //    powerUpCanvas.SetActive(false);
        //}
        //else if (x == 0 && y == 0)
        //{
             
        //}
    }
}
