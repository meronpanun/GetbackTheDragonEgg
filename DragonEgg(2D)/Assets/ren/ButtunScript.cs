using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtunScript : MonoBehaviour
{
    //private Vector2 tmp;
    //public GameObject camera;
    //public static float x, y;

    //// ボタンが押された場合、今回呼び出される関数

    //// Start is called before the first frame update
    //void Start()
    //{
    //    camera = GameObject.Find("CameraController");

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    tmp = GameObject.Find("Main Camera").transform.position;
    //    x = tmp.x;
    //    y = tmp.y;
    //    if (Input.GetKeyDown(KeyCode.Escape))//強化画面からモンスターBOXへ
    //    {
    //        CameraContoller.CameraMove1();

    //    }

    //    if (CameraContoller.flag == 1)
    //    {
    //        CameraContoller.powerUpCanvas.SetActive(false);
    //        CameraContoller.canvas.SetActive(true);
    //        CameraContoller.MonsterBox(y);
    //    }
    //    else if (CameraContoller.flag == 0)
    //    {
    //        CameraContoller.powerUpCanvas.SetActive(true);
    //        CameraContoller.canvas.SetActive(false);
    //    }
    //}
    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        CameraContoller.CameraMove1();
    }

}
