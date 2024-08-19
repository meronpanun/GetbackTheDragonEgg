// ステージに入る際に表示させるメッセージを操作するスクリプト

// 表示+徐々に文字が表示される+
// メッセージが全て表示されたらボタン表示+
// スペースキーを押すとメッセージを即全部表示
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 卵とか
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;  // sleep用



public class DispResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private GameObject _goHomeButton;
    [SerializeField] private GameObject _goStageButton;
    [SerializeField] private GameObject _dragonImage1;
    [SerializeField] private GameObject _dragonImage2;
    [SerializeField] private GameObject _dragonImage3;
    [SerializeField] private GameObject _dragonImage4;
    [TextArea(5, 5)]
    //
    private GameObject _dispDragonImage;

    private const string kSceneName = "ClearScene";
    private const string kPlayerPrefsKey = "Progress";

    private float msgSpeed = 0.03f;  // テキスト表示間隔
    private float msgLineSpeedEnter = 0.08f;  // 改行時待機時間
    private float msgSpeedEnter = 0.01f;  // 時待機時間
    private int dragonAnimNum = 10;  // アニメーションの割る数
    private float dragonAnimSpeed = 0.6f;  // アニメーションの速度

    private float dragonScale = 3.5f;

    //int stageNum = 0;
    string dialogText = "";  // 非同期処理のforeach文の指定でつっかえたので変数を作って解決させた

    [SerializeField] private GameObject Panel;

    // 直前にクリアしてきたステージ
    int clearStageNum = 0;
    // trueになるとdragon表示
    bool isFirstClear = false;
    

    void Start()
    {
        _goHomeButton.SetActive(false);  // ボタンを隠す
        _goStageButton.SetActive(false);
        _dragonImage1.SetActive(false);
        _dragonImage2.SetActive(false);
        _dragonImage3.SetActive(false);
        _dragonImage4.SetActive(false);
        //StartCoroutine(TypeDisplay());

        DispResultFunc();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:0");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:1");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 1);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:2");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 2);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:3");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 3);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:4");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 4);
        }

        // バグりそうなので廃止
        //if (Input.GetKey(KeyCode.Space)) // スペースキーが押されたら
        //{
        //    StopAllCoroutines();

            //    //DialogText.text = dialogText;  // DialogText.text関数にdialogText変数の中身を代入
            //    _resultText.text = "";
            //    foreach (char item in dialogText)
            //    {
            //        if (item == '|')
            //        {
            //            // <br>をDialogText.textに代入する
            //            _resultText.text += "<br>";
            //        }
            //        else if (item == '/')
            //        {
            //            // 何もしない
            //        }
            //        else
            //        {
            //            _resultText.text += item;  // 
            //        }
            //    }

            //    _dispDragonImage = GetDispDragonImage();

            //    // 初クリアならドラゴンを表示
            //    if (isFirstClear) _dispDragonImage.SetActive(true);

            //    _goHomeButton.SetActive(true);  // ボタンを表示
            //    _goStageButton.SetActive(true);
            //}
    }

    public void DispResultFunc()
    {
        // 0~4
        //int debug = 0;
        //PlayerPrefs.SetInt(kPlayerPrefsKey, debug);

        //Debug.Log($"DispResultFunc.Debug PlayerPrefs.{kPlayerPrefsKey} = {debug}");

        clearStageNum = GetClearStageNum();

        // debug
        //isFirstClear = true;
        //clearStageNum = 4;

        Debug.Log($"DispResultFunc.Debug isFirstClear = {isFirstClear}");



        _resultText.text = "";
        dialogText = "//////S/t/a/g/e// C/l/e/a/r/!/!/||";  // dialogText変数に文を代入

        if (isFirstClear)
        {
            // 初クリアなら
            dialogText += "Rescue Dragon///|";
        }

        _goHomeButton.SetActive(false);  // ボタンを隠す
        _goStageButton.SetActive(false);

        StartCoroutine(TypeDisplay());  // メッセージ表示を開始
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
        _goHomeButton.SetActive(false);  // ボタンを隠す
        _goStageButton.SetActive(false);
        //_dragonImage1.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>をDialogText.textに代入する
                _resultText.text += "<br>";
                yield return new WaitForSeconds(msgLineSpeedEnter);
            }
            else if (item == '.')
            {
                _resultText.text += item;
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else if (item == '/')
            {
                // 表示せず待つだけ
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else
            {
                _resultText.text += item;  // 
            }


            yield return new WaitForSeconds(msgSpeed);  // メッセージをmsgSpeed毎に表示？
        }

        if (isFirstClear)
        {
            StartCoroutine(EggAnim());  // 卵表示を開始
        }
        else
        {
            _goHomeButton.SetActive(true);  // ボタンを表示
            _goStageButton.SetActive(true);
        }
        
    }

    IEnumerator EggAnim()  // 卵からドラゴンへ変える
    {
        _dispDragonImage = GetDispDragonImage();


        _dispDragonImage.SetActive(true);  // ドラゴンを表示

        RectTransform dragonRectTransform = _dispDragonImage.GetComponent<RectTransform>();
        //Transform dragonTransform = DispDragonImage.GetComponent<Transform>();
        for (float i = 0; i < dragonAnimNum; i++)
        {
            //Debug.Log($"{(dragonAnimSpeed / dragonAnimNum) * dragonScale}");
            // ドラゴンの大きさを徐々に大きくする
            dragonRectTransform.localScale = new Vector3((i / dragonAnimNum) * dragonScale, (i / dragonAnimNum) * dragonScale, 0);
            //dragonTransform.localScale = new Vector3((i / dragonAnimNum) * dragonScale, (i / dragonAnimNum) * dragonScale, 0);
            yield return new WaitForSeconds(dragonAnimSpeed / dragonAnimNum);
        }
        dragonRectTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        //dragonTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        Debug.Log(dragonRectTransform.localScale);

        _goHomeButton.SetActive(true);  // ボタンを表示
        _goStageButton.SetActive(true);

        yield return 0;
    }

    private GameObject GetDispDragonImage()
    {
        GameObject GameObject = _dragonImage1;

        switch (clearStageNum)
        {
            case 1:
                GameObject = _dragonImage1;
                break;

            case 2:
                GameObject = _dragonImage2;
                break;

            case 3:
                GameObject = _dragonImage3;
                break;

            case 4:
                GameObject = _dragonImage4;
                break;

            default:
                Debug.Log("EggAnimError");
                break;
        }

        return GameObject;
    }

    private int GetClearStageNum()
    {
        // 直前にクリアしたステージを今のシーンの名前から求める
        string s = SceneManager.GetActiveScene().name;


        Debug.Log(s);

        for (int i = 1; i < 5; i++)
        {
            Debug.Log(kSceneName + i);
            // 見つかったら代入しbreak
            if (s == kSceneName + i) { clearStageNum = i; break; }
        }

        // エラー処理
        if (clearStageNum == 0) { Debug.Log("SceneNumError"); return 0; }

        // valueは今まででクリアしたステージの最高値
        int value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        Debug.Log($"v = {value}, num = {clearStageNum}");

        // valueを1だけ(valueより、でもいいかも)更新したら
        if (value == clearStageNum - 1)
        {
            PlayerPrefs.SetInt(kPlayerPrefsKey, clearStageNum);
            isFirstClear = true;
        }

        return clearStageNum;
    }
}