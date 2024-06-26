// ステージに入る際に表示させるメッセージを操作するスクリプト

// 表示+徐々に文字が表示される+
// メッセージが全て表示されたらボタン表示+
// スペースキーを押すとメッセージを即全部表示
using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading;  // sleep用


public class DispResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultText;
    [SerializeField] private GameObject GoHomeButton;
    [SerializeField] private GameObject GoStageButton;
    [TextArea(5, 5)]
    //[SerializeField] private string msgText;  // 使わなくなった
    private float msgSpeed = 0.03f;  // テキスト表示間隔
    private float msgSpeedEnter = 0.08f;  // 改行時待機時間

    //int stageNum = 0;
    string dialogText = "";  // 非同期処理のforeach文の指定でつっかえたので変数を作って解決させた

    [SerializeField] private GameObject Panel;

    int test = 0;

    void Start()
    {
        //DialogText.text = dialogText;
        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);
        //StartCoroutine(TypeDisplay());

        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && test == 0) // スペースキーが押されたら
        {
            DispResultFunc();
            test++;
            //StopAllCoroutines();
            ////DialogText.text = dialogText;  // DialogText.text関数にdialogText変数の中身を代入
            //ResultText.text = "";
            //foreach (char item in dialogText)
            //{
            //    if (item == '|')
            //    {
            //        // <br>をDialogText.textに代入する
            //        ResultText.text += "<br>";
            //    }
            //    else
            //    {
            //        ResultText.text += item;  // 
            //    }
            //}

            ////DialogText.text = msgText;  // 使わなくなった
            //GoHomeButton.SetActive(true);  // ボタンを表示
            //GoStageButton.SetActive(true);
        }
    }

    public void DispResultFunc()
    {
        //ResultText.text = "獲得した経験値 ... " + "(獲得経験値)||" + "助けたドラゴン|" + "(画像)";
        //ResultText.text = "Get EXP ... " + "(GetEXP)||" + "Rescue Dragon|" + "(dragon.png)";
        //dialogText = "";  // dialogText変数に文を代入
        ResultText.text = "";
        dialogText = "Get EXP ... " + "(GetEXP)||" + "Rescue Dragon|" + "(dragon.png)";  // dialogText変数に文を代入

        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);

        //StartCoroutine(ScaleChange());
        StartCoroutine(TypeDisplay());  // メッセージ表示を開始


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
        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>をDialogText.textに代入する
                ResultText.text += "<br>";
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else if (item == '.')
            {
                ResultText.text += item;
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