using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    public static GameObject selectUI;//あとで変更
    public static GameObject powerUpCanvas;
    public static GameObject DragonBoxUITeam;//あとで変更
    public static GameObject DragonBoxUIPowerUp;//あとで変更
    public static GameObject teamCastam;//あとで変更
    
    bool boxFlag = false;//ボックス
    bool powerUpFlag = false;//強化モードを選んだかどうか
    bool teamFlag = false;//編成モードを選んだかどうか



    //public RectTransform childDragonIcon;//RectTransform型の変数aを宣言　作成したテキストオブジェクトをアタッチしておく
    void Start()
    {
        //セレクト画面のUI
        selectUI = GameObject.Find("SelectUI");
        Debug.Log("通ります");
        //セレクト画面を最初の画面にする
        MoveSelectMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //Escapeキーを押すとひとつ前の画面に戻る
        if (boxFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            MoveSelectMenu();
        }
        if (powerUpFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            MoveMonsterBoxPowerUp();
        }
        if (teamFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            MoveMonsterBoxTeam();
        }
    }
    // Start is called before the first frame update
    //セレクト画面に移動する際呼び出される関数
    public void MoveSelectMenu()
    {
        selectUI.SetActive(true);
        boxFlag = false;
        powerUpFlag = false;
    }
    //編成(Team)を押した際のモンスターBOX画面に移動する際呼び出される関数
    public void MoveMonsterBoxTeam()
    {
        selectUI.SetActive(false);
        boxFlag = true;
        teamFlag = false;
    }
    //強化(PowerUp)を押した際のモンスターBOX画面に移動する際呼び出される関数
    public void MoveMonsterBoxPowerUp()
    {
        selectUI.SetActive(false);
        boxFlag = true;
        powerUpFlag = false;
    }
    //強化画面に移動する際呼び出される関数
    public void MovePowerUp()
    {
        selectUI.SetActive(false);
        boxFlag = false;
        powerUpFlag = true;
    }

}
