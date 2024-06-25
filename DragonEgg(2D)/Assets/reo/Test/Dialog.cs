// ステージに入る際に表示させるメッセージを操作するスクリプト

// 表示+徐々に文字が表示される+
// メッセージが全て表示されたらボタン表示+
// スペースキーを押すとメッセージを即全部表示
using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading;  // sleep用


public class DialogBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject NoButton;
    [SerializeField] private GameObject GoButton;
    [TextArea(5, 5)]
    //[SerializeField] private string msgText;  // 使わなくなった
    private float msgSpeed = 0.03f;  // テキスト表示間隔
    private float msgSpeedEnter = 0.08f;  // 改行時待機時間

    //int stageNum = 0;
    string dialogText = "";  // 非同期処理のforeach文の指定でつっかえたので変数を作って解決させた

    [SerializeField] private GameObject Panel;

    void Start()
    {
        //DialogText.text = dialogText;
        NoButton.SetActive(false);  // ボタンを隠す
        GoButton.SetActive(false);
        //StartCoroutine(TypeDisplay());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // スペースキーが押されたら
        {
            StopAllCoroutines();
            //DialogText.text = dialogText;  // DialogText.text関数にdialogText変数の中身を代入
            DialogText.text = "";
            foreach (char item in dialogText)
            {
                if (item == '|')
                {
                    // <br>をDialogText.textに代入する
                    DialogText.text += "<br>";
                }
                else
                {
                    DialogText.text += item;  // 
                }
            }

            //DialogText.text = msgText;  // 使わなくなった
            NoButton.SetActive(true);  // ボタンを表示
            GoButton.SetActive(true);
        }
    }

    public void Push_Button(int number)
    {
        // クラス名.変数名
        LoadingScene.stageNum = number;  // ボタン側からステージ数を取得
        DialogText.text = "";
        dialogText = "Stage " + LoadingScene.stageNum + "||Ready?";  // dialogText変数に文を代入

        NoButton.SetActive(false);  // ボタンを隠す
        GoButton.SetActive(false);

        StartCoroutine(ScaleChange());
        
        //Debug.Log("Stage " + LoadingScene.stageNum + "||Ready?");
        //Debug.Log(DialogText.text);
    }

    IEnumerator ScaleChange()  // サイズを徐々に大きくする
    {
        // 徐々に大きくする
        for (int i = 0; i < 10; i++)
        {
            Panel.transform.localScale = new Vector3(i / 10f, i / 10f, 1);
            yield return new WaitForSeconds(0.06f);
        }
        // scaleを1にする(保険)
        Panel.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(TypeDisplay());  // メッセージ表示を開始
    }

    IEnumerator TypeDisplay()  // メッセージを表示させる機構？ IEnumeratorは非同期処理を行うために用いるデータ型の一種
    {
        NoButton.SetActive(false);  // ボタンを隠す
        GoButton.SetActive(false);

        foreach (char item in dialogText)
        {
            if(item == '|')
            {
                // <br>をDialogText.textに代入する
                DialogText.text += "<br>";
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else
            {
                DialogText.text += item;  // 
            }

            
            yield return new WaitForSeconds(msgSpeed);  // メッセージをmsgSpeed毎に表示？
        }
        NoButton.SetActive(true);  // ボタンを表示
        GoButton.SetActive(true);
    }
}