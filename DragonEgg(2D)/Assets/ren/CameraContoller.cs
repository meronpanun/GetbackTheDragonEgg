using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class CameraContoller : MonoBehaviour
{ 
    public static GameObject powerUpCanvas;
    public static GameObject icon;//あとで変更
    public Vector3 cameraPos;
    bool boxFlag = false;
    bool powerUpFlag = false;
    bool teamFlag = false;
    bool SelectFlag = false;



    //public RectTransform childDragonIcon;//RectTransform型の変数aを宣言　作成したテキストオブジェクトをアタッチしておく
    void Start()
    {
        powerUpCanvas = GameObject.Find("PowerUpCanvas");
        icon = GameObject.Find("ChildDragonIcon");
        CameraMoveSelectMenu();
    }

    // Update is called once per frame
    void Update()
    {
       // this.transform.Translate(0f, 0.1f, 0f);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            if (transform.position.y <= 0.00f && boxFlag)
            {
                transform.Translate(0f, 0.1f, 0f);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
            //現在の位置からx方向に1移動する
           
            if (transform.position.y >= -28.00f && boxFlag)
            {
                transform.Translate(0f, -0.1f, 0f);
            }
        }
        //現在の位置を取得
        Vector3 pos = this.gameObject.transform.position;
       
        if (boxFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveSelectMenu();
        }
        if (powerUpFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveMonsterBoxPowerUp();
        }
        if (teamFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveMonsterBoxTeam();
        }
    }
    // Start is called before the first frame update
    public void CameraMoveSelectMenu()
    {
        transform.position = new Vector3(-160, 0, -10);
        powerUpCanvas.SetActive(false);
        icon.SetActive(false);
        boxFlag = false;
        powerUpFlag = false;
    }
    public void CameraMoveMonsterBoxTeam()
    {
        transform.position = new Vector3(-240, 0, -10);
        powerUpCanvas.SetActive(false);
        icon.SetActive(true);
        boxFlag = true;
        teamFlag = false;
    } 
    public void CameraMoveMonsterBoxPowerUp()
    {
        transform.position = new Vector3(-80, 0, -10);
        powerUpCanvas.SetActive(false);
        icon.SetActive(true);
        boxFlag = true;
        powerUpFlag = false;
    }
    public void CameraMovePowerUp()
    {
        if(SelectFlag == true)
        {
            Debug.Log("選択したよ");
        }
        else
        {
            transform.position = new Vector3(0, 0, -10);
            powerUpCanvas.SetActive(true);
            icon.SetActive(false);
            boxFlag = false;
            powerUpFlag = true;
        }
    }
    public void SelectMode1()
    {
        SelectFlag = true;
        CameraMoveMonsterBoxTeam();
    }
    public void SelectMode2()
    {
        SelectFlag = false;
        CameraMoveMonsterBoxPowerUp();
    }


    public void MonsterBox()//カメラがきれいにy=0で止まらない　動作的には問題ないけど気になるから今後修正
    {
       
    }


}
