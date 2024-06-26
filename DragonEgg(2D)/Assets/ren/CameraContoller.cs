using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class CameraContoller : MonoBehaviour
{ 
    public static GameObject powerUpCanvas;
    public static GameObject iconUI;//あとで変更
    public static GameObject teamCastam;//あとで変更
    public static GameObject selectUI;//あとで変更
    public Vector3 cameraPos;//カメラの位置
    bool boxFlag = false;//ボックス
    bool powerUpFlag = false;//強化モードを選んだかどうか
    bool teamFlag = false;//編成モードを選んだかどうか



    //public RectTransform childDragonIcon;//RectTransform型の変数aを宣言　作成したテキストオブジェクトをアタッチしておく
    void Start()
    {
        //強化画面でのUI
        powerUpCanvas = GameObject.Find("PowerUpUI");
        //モンスターBOXでのUI
        iconUI = GameObject.Find("ChildDragonIcon_Test");
        //編成でのUI
        teamCastam = GameObject.Find("TeamCastam");
        //セレクト画面のUI
        selectUI = GameObject.Find("SelectUI");
        //セレクト画面を最初の画面にする
        CameraMoveSelectMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //モンスターボックスでのカメラの移動
        MonsterBox();

        //現在の位置を取得
        Vector3 pos = this.gameObject.transform.position;
       //Escapeキーを押すとひとつ前の画面に戻る
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
    //セレクト画面に移動する際呼び出される関数
    public void CameraMoveSelectMenu()
    {
        transform.position = new Vector3(-160, 0, -10);
        selectUI.SetActive(true);
        powerUpCanvas.SetActive(false);
        iconUI.SetActive(false);
        teamCastam.SetActive(false);
        boxFlag = false;
        powerUpFlag = false;
    }
    //編成(Team)を押した際のモンスターBOX画面に移動する際呼び出される関数
    public void CameraMoveMonsterBoxTeam()
    {
        transform.position = new Vector3(-240, 0, -10);
        selectUI.SetActive(false);
        powerUpCanvas.SetActive(false);
        iconUI.SetActive(false);
        teamCastam.SetActive(true);
        boxFlag = true;
        teamFlag = false;
    }
    //強化(PowerUp)を押した際のモンスターBOX画面に移動する際呼び出される関数
    public void CameraMoveMonsterBoxPowerUp()
    {
        transform.position = new Vector3(-80, 0, -10);
        selectUI.SetActive(false);
        powerUpCanvas.SetActive(false);
        iconUI.SetActive(true);
        teamCastam.SetActive(false);
        boxFlag = true;
        powerUpFlag = false;
    }
    //強化画面に移動する際呼び出される関数
    public void CameraMovePowerUp()
    {
        transform.position = new Vector3(0, 0, -10);
        selectUI.SetActive(false);
        powerUpCanvas.SetActive(true);
        iconUI.SetActive(false);
        teamCastam.SetActive(false);
        boxFlag = false;
        powerUpFlag = true;
    }
    
    //モンスターBOXでのカメラ制御
    public void MonsterBox()//カメラがきれいにy=0で止まらない　動作的には問題ないけど気になるから今後修正
    {
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
    }


}
