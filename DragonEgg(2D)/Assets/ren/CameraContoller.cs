using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraContoller : MonoBehaviour
{
    private Vector2 tmp;
    public static GameObject powerUpCanvas;
    public static GameObject icon;//あとで変更
    public static int flag = 1;
    public GameObject camera;
    float x, y;

    //public RectTransform childDragonIcon;//RectTransform型の変数aを宣言　作成したテキストオブジェクトをアタッチしておく
    void Start()
    {
        // tmp = GameObject.Find("Main Camera").transform.position;
        powerUpCanvas = GameObject.Find("PowerUpCanvas");
        icon = GameObject.Find("ChildDragonIcon");
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(flag);
        tmp = camera.transform.position;
        x = tmp.x;
        y = tmp.y;
        //Debug.Log(y);

        if (flag == 0)
        {
            CameraMove0();
            powerUpCanvas.SetActive(false);
            icon.SetActive(false);
        }
        if (flag == 1)
        {
            powerUpCanvas.SetActive(false);
            icon.SetActive(true);
            MonsterBox(y);
            CameraMove1();
        }
        if (flag == 2)
        {
            powerUpCanvas.SetActive(true);
            icon.SetActive(false);
            CameraMove2();
        }

        //なぜか0になるくそ
        //if (Input.GetKeyDown(KeyCode.Escape) && flag == 2)//強化画面からモンスターBOXへ
        //{
        //    CameraMove1();
        //}
        //if (Input.GetKeyDown(KeyCode.Escape) && flag == 1)
        //{
        //    CameraMove0();
        //}
    }

    // Start is called before the first frame update
    public static void CameraMove0()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(-160, 0, -10);
        flag = 0;
    }
    public static void CameraMove1()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(-80, 0, -10);
        flag = 1;
    }
    public static void CameraMove2()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
        flag = 2;
    }


    public void MonsterBox(float y)//カメラがきれいにy=0で止まらない　動作的には問題ないけど気になるから今後修正
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            camera.transform.position += new Vector3(0.0f, 0.01f, 0.0f); //カメラを上へ移動。
            if (y >= 0.00f)
            {
               camera.transform.position = new Vector3(-80.0f, 0.01f, -10.0f);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("donw");
            camera.transform.position += new Vector3(0.0f, -0.01f, 0.0f); //カメラを下へ移動。
            if (y <= -28.00f)
            {
                camera.transform.position = new Vector3(-80.0f, -28.00f, -10.0f);
            }
        }
    }
}
