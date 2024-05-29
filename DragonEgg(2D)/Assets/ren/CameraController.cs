using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class BootsupandsquadManager : MonoBehaviour
{
    private Vector2 tmp;
    GameObject powerUpCanvas;
    int flag = 0;

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
            GameObject.Find("Main Camera").transform.position = new Vector3(-80, 0,-10);
            flag = 1;

        }
        if (Input.GetKeyDown(KeyCode.Space) && flag != 0)
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(0,0,-10);
            flag = 0;

        }

        if (flag == 1)
        {
            powerUpCanvas.SetActive(false);
        }
        else if (flag == 0)
        {
            powerUpCanvas.SetActive(true);
        }

    }
}

