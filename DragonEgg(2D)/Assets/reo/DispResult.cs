// ステージに入る際に表示させるメッセージを操作するスクリプト

// 表示+徐々に文字が表示される+
// メッセージが全て表示されたらボタン表示+
// スペースキーを押すとメッセージを即全部表示
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 卵とか
using TMPro;
using System.Threading;  // sleep用


public class DispResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultText;
    [SerializeField] private GameObject GoHomeButton;
    [SerializeField] private GameObject GoStageButton;
    [SerializeField] private GameObject EggImage;
    [SerializeField] private GameObject DragonImage1;
    [SerializeField] private GameObject DragonImage2;
    [SerializeField] private GameObject DragonImage3;
    [SerializeField] private GameObject DragonImage4;
    [TextArea(5, 5)]

    private GameObject DispDragonImage;
    //[SerializeField] private string msgText;  // 使わなくなった

    private float msgSpeed = 0.03f;  // テキスト表示間隔
    private float msgLineSpeedEnter = 0.08f;  // 改行時待機時間
    private float msgSpeedEnter = 0.01f;  // 時待機時間
    //private float summonDragonSpeed = 0.2f;  // ドラゴンを表示するまでの待機時間
    //private float summonDragonFirstSpeed = 0.5f;  // ドラゴンを表示するまでの待機時間
    //private int eggAnimNum = 8;  // 入れ替える回数
    private int eggAnimNum = 10;  // アニメーションの割る数
    private float eggAnimSpeed = 0.6f;  // アニメーションの速度
    //private int tempExp = 1234567;  // exp(仮)

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
        EggImage.SetActive(false);
        DragonImage1.SetActive(false);
        DragonImage2.SetActive(false);
        DragonImage3.SetActive(false);
        DragonImage4.SetActive(false);
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

            //DialogText.text = msgText;  // 使わなくなった
            GoHomeButton.SetActive(true);  // ボタンを表示
            GoStageButton.SetActive(true);

            DragonImage1.SetActive(true);  // ドラゴンを表示
        }
    }

    public void DispResultFunc()
    {
        //ResultText.text = "獲得した経験値 ... " + "(獲得経験値)||" + "助けたドラゴン|" + "(画像)";
        //ResultText.text = "Get EXP ... " + "(GetEXP)||" + "Rescue Dragon|" + "(dragon.png)";
        //dialogText = "";  // dialogText変数に文を代入
        ResultText.text = "";
        //dialogText = "Get EXP ... " + tempExp + "||" + "Rescue Dragon|";  //  + "(dragon.png)" dialogText変数に文を代入
        dialogText = "//////S/t/a/g/e// C/l/e/a/r/!/!/||" + "Rescue Dragon///|";  //  + "(dragon.png)" dialogText変数に文を代入

        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);
        EggImage.SetActive(false);
        DragonImage1.SetActive(false);

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

    IEnumerator TypeDisplay()  // メッセージを表示させる機構 IEnumeratorは非同期処理を行うために用いるデータ型の一種
    {
        GoHomeButton.SetActive(false);  // ボタンを隠す
        GoStageButton.SetActive(false);
        EggImage.SetActive(false);
        DragonImage1.SetActive(false);

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

        if (isFirstClear)
        {
            StartCoroutine(EggAnim());  // 卵表示を開始
        }
        else
        {

        }
        
    }

    IEnumerator EggAnim()  // 卵からドラゴンへ変える
    {
        switch (clearStageNum)
        {
            case 1:
                DispDragonImage = DragonImage1;
                break;

            case 2:
                DispDragonImage = DragonImage2;
                break;

            case 3:
                DispDragonImage = DragonImage3;
                break;

            case 4:
                DispDragonImage = DragonImage4;
                break;

            default:
                Debug.Log("EggAnimError");
                break;
        }
        

        EggImage.SetActive(true);
        //yield return new WaitForSeconds(summonDragonFirstSpeed);


        //// 旧処理
        //for (int i = 0; i < eggAnimNum; i++)
        //{
        //    DragonImage.SetActive(false);
        //    EggImage.SetActive(true);  // 卵を表示

        //    yield return new WaitForSeconds(summonDragonSpeed);

        //    EggImage.SetActive(false);  // 卵を隠す
        //    DragonImage.SetActive(true);  // ドラゴンを表示

        //    yield return new WaitForSeconds(summonDragonSpeed);

        //    summonDragonSpeed *= 0.85f;
        //}


        // 新処理
        //RectTransform eggRectTransform = EggImage.GetComponent<RectTransform>();
        //for (float i = eggAnimNum; i > 0; i--)
        //{
        //    Debug.Log($"{eggAnimSpeed / eggAnimNum}");
        //    // 卵の大きさを徐々に小さくする
        //    eggRectTransform.localScale = new Vector3(i / eggAnimNum, i / eggAnimNum, 0);
        //    yield return new WaitForSeconds(eggAnimSpeed / eggAnimNum);
        //}

        EggImage.SetActive(false);  // 卵を隠す
        DispDragonImage.SetActive(true);  // ドラゴンを表示

        RectTransform dragonRectTransform = DispDragonImage.GetComponent<RectTransform>();
        //Transform dragonTransform = DispDragonImage.GetComponent<Transform>();
        for (float i = 0; i < eggAnimNum; i++)
        {
            Debug.Log($"{(eggAnimSpeed / eggAnimNum) * dragonScale}");
            // ドラゴンの大きさを徐々に大きくする
            dragonRectTransform.localScale = new Vector3((i / eggAnimNum) * dragonScale, (i / eggAnimNum) * dragonScale, 0);
            //dragonTransform.localScale = new Vector3((i / eggAnimNum) * dragonScale, (i / eggAnimNum) * dragonScale, 0);
            yield return new WaitForSeconds(eggAnimSpeed / eggAnimNum);
        }
        dragonRectTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        //dragonTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        Debug.Log(dragonRectTransform.localScale);

        GoHomeButton.SetActive(true);  // ボタンを表示
        GoStageButton.SetActive(true);

        yield return 0;
    }
}