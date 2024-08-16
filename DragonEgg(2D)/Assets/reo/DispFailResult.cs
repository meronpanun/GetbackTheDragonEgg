// ステージに入る際に表示させるメッセージを操作するスクリプト

// 表示+徐々に文字が表示される+
// メッセージが全て表示されたらボタン表示+
// スペースキーを押すとメッセージを即全部表示
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 卵とか
using TMPro;
using System.Threading;  // sleep用


public class DispFailResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultText;
    [SerializeField] private GameObject GoHomeButton;
    [SerializeField] private GameObject GoStageButton;
    [TextArea(5, 5)]

    private GameObject DispDragonImage;

    private float msgSpeed = 0.03f;  // テキスト表示間隔
    private float msgLineSpeedEnter = 0.08f;  // 改行時待機時間
    private float msgSpeedEnter = 0.01f;  // 時待機時間
    private int eggAnimNum = 10;  // アニメーションの割る数
    private float eggAnimSpeed = 0.6f;  // アニメーションの速度

    float dragonScale = 3.5f;

    //int stageNum = 0;
    string dialogText = "";  // 非同期処理のforeach文の指定でつっかえたので変数を作って解決させた

    [SerializeField] private GameObject Panel;

    //int test = 0;


    // ゲームシーンからクリアしたステージと初クリアかどうかを貰う
    int clearStageNum = 1;
    bool isFirstClear = false;

    // 


    void Start()
    {
        //DialogText.text = dialogText;
        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);
        //StartCoroutine(TypeDisplay());

        DispResultFunc();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // スペースキーが押されたら
        {
            StopAllCoroutines();
            //DialogText.text = dialogText;  // DialogText.text関数にdialogText変数の中身を代入
            ResultText.text = "";
            foreach (char item in dialogText)
            {
                if (item == '|')
                {
                    // <br>をDialogText.textに代入する
                    ResultText.text += "<br>";
                }
                else if (item == '/')
                {
                    // 何もしない
                }
                else
                {
                    ResultText.text += item;  // 
                }
            }

            GoHomeButton.SetActive(true);  // ボタンを表示
            GoStageButton.SetActive(true);
        }
    }

    public void DispResultFunc()
    {
        ResultText.text = "";
        
        dialogText = "|//////S/t/a/g/e// F/a/i/l/e/d/...///||" + "Continue?";  //  + "(dragon.png)" dialogText変数に文を代入

        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);

        //StartCoroutine(ScaleChange());
        StartCoroutine(TypeDisplay());  // メッセージ表示を開始


        //Debug.Log("Stage " + LoadingScene.stageNum + "||Ready?");
        //Debug.Log(DialogText.text);
    }

    IEnumerator TypeDisplay()  // メッセージを表示させる機構 IEnumeratorは非同期処理を行うために用いるデータ型の一種
    {
        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>をDialogText.textに代入する
                ResultText.text += "<br>";
                yield return new WaitForSeconds(msgLineSpeedEnter);
            }
            else if (item == '.')
            {
                ResultText.text += item;
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else if (item == '/')
            {
                // 表示せず待つだけ
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else
            {
                ResultText.text += item;  // 
            }

            yield return new WaitForSeconds(msgSpeed);  // メッセージをmsgSpeed毎に表示？
        }

        GoHomeButton.SetActive(true);  // ボタンを表示
        GoStageButton.SetActive(true);

    }
}