using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class CameraContoller : MonoBehaviour
{ 
    public static GameObject powerUpCanvas;
    public static GameObject icon;//あとで変更
    public static int flag = 1;
    public Vector3 pos;




    //public RectTransform childDragonIcon;//RectTransform型の変数aを宣言　作成したテキストオブジェクトをアタッチしておく
    void Start()
    {
        powerUpCanvas = GameObject.Find("PowerUpCanvas");
        icon = GameObject.Find("ChildDragonIcon");
       
    }

    // Update is called once per frame
    void Update()
    {
        //現在の位置を取得
        Vector3 pos = this.gameObject.transform.position;
        
        //Transform myTransform = this.transform;
        //Vector3 Pos = Transform.position;
        //Pos.x = -80.0f; // x座標変更
        //Pos.y = 0.0f; // y座標変更
        //Pos.z = -10.0f; // z座標変更
        //transform.position = Pos; // 変更後の座標を代入
        Debug.Log(flag);
        //x = tmp.x;
        //y = tmp.y;
        //Debug.Log(y);

        if (flag == 0)//なぜか0になる
        {
            CameraMove0();
            powerUpCanvas.SetActive(false);
            icon.SetActive(false);
            
        }
        if (flag == 1)
        {
            powerUpCanvas.SetActive(false);
            icon.SetActive(true);
            MonsterBox();
            CameraMove1();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                flag = 0;
            }
        }
        if (flag == 2)
        {
            powerUpCanvas.SetActive(true);
            icon.SetActive(false);
            CameraMove2();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                flag = 1;
            }
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


    public void MonsterBox()//カメラがきれいにy=0で止まらない　動作的には問題ないけど気になるから今後修正
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            this.gameObject.transform.position = new Vector3(pos.x, pos.y + 0.01f, pos.z);
            //myTransform.Translate(0.0f, 0.01f, 0.0f);
            //transform.Translate(0.0f, 0.01f, 0.0f);
           // camera.transform.position += new Vector3(0.0f, 0.01f, 0.0f); //カメラを上へ移動。
            //if (y >= 0.00f)
            //{
            //    camera.transform.position = new Vector3(-80.0f, 0.01f, -10.0f);
            //}
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("donw");
            //現在の位置からx方向に1移動する
            this.gameObject.transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);
            //myTransform.Translate(0.0f, -0.01f, 0.0f);
            //transform.Translate(0.0f, -0.01f, 0.0f);
            //camera.transform.position += new Vector3(0.0f, -0.01f, 0.0f); //カメラを下へ移動。
            //if (y <= -28.00f)
            //{
            //    camera.transform.position = new Vector3(-80.0f, -28.00f, -10.0f);
            //}
        }
    }


}
