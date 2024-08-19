// ステージに入る際に表示させるメッセージを操作するスクリプト

// 表示+徐々に文字が表示される+
// メッセージが全て表示されたらボタン表示+
// スペースキーを押すとメッセージを即全部表示
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;  // sleep用
using UnityEngine.EventSystems;


public class DialogBuild : MonoBehaviour
{
    [SerializeField] private StageSelect _stageSelect;

    [SerializeField] private AudioSource _negativeSe;
    [SerializeField] private AudioSource _positiveSe;

    [SerializeField] private Image _button1Image;
    [SerializeField] private Image _button2Image;
    [SerializeField] private Image _button3Image;
    [SerializeField] private Image _button4Image;

    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject NoButton;
    [SerializeField] private GameObject GoButton;

    [SerializeField] private Image _selectPanelImage;

    [SerializeField] private Sprite _selectPanelSprite1;
    [SerializeField] private Sprite _selectPanelSprite2;
    [SerializeField] private Sprite _selectPanelSprite3;
    [SerializeField] private Sprite _selectPanelSprite4;
    [TextArea(5, 5)]

    private const string kPlayerPrefsKey = "Progress";

    private float red1, green1, blue1, alpha1;
    private float red2, green2, blue2, alpha2;
    private float red3, green3, blue3, alpha3;
    private float red4, green4, blue4, alpha4;
    
    private bool isStage1 = false;
    private bool isStage2 = false;
    private bool isStage3 = false;
    private bool isStage4 = false;

    private const float kStopColor = 0.6f;
    private const float kDefaultColor = 1.0f;

    //[SerializeField] private string msgText;  // 使わなくなった
    private float msgSpeed = 0.03f;  // テキスト表示間隔
    private float msgSpeedEnter = 0.08f;  // 改行時待機時間

    //int stageNum = 0;
    string dialogText = "";  // 非同期処理のforeach文の指定でつっかえたので変数を作って解決させた

    [SerializeField] private GameObject Panel;

    void Start()
    {
        // ボタンの色、不透明度情報
        //_button1Image = GetComponent<Image>();
        //_button2Image = GetComponent<Image>();
        //_button3Image = GetComponent<Image>();
        //_button4Image = GetComponent<Image>();

        red1 = _button1Image.color.r;
        green1 = _button1Image.color.g;
        blue1 = _button1Image.color.b;
        alpha1 = _button1Image.color.a;

        red2 = _button2Image.color.r;
        green2 = _button2Image.color.g;
        blue2 = _button2Image.color.b;
        alpha2 = _button2Image.color.a;

        red3 = _button3Image.color.r;
        green3 = _button3Image.color.g;
        blue3 = _button3Image.color.b;
        alpha3 = _button3Image.color.a;

        red4 = _button4Image.color.r;
        green4 = _button4Image.color.g;
        blue4 = _button4Image.color.b;
        alpha4 = _button4Image.color.a;

        // valueは今まででクリアしたステージの最高値
        int value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        Debug.Log($"{red1}{green1}{blue1}");

        switch (value)
        {
            case 0: // クリアなし
                // 2,3,4制限
                isStage1 = true;
                isStage2 = false;
                isStage3 = false;
                isStage4 = false;
                break;

            case 1:
                // 3,4
                isStage1 = true;
                isStage2 = true;
                isStage3 = false;
                isStage4 = false;
                break;

            case 2:
                // 4のみ
                isStage1 = true;
                isStage2 = true;
                isStage3 = true;
                isStage4 = false;
                break;

            case 3:
            case 4:
            default:
                // 全ステージ挑戦可
                isStage1 = true;
                isStage2 = true;
                isStage3 = true;
                isStage4 = true;
                break;
        }

        StageButtonChangeColor(1, isStage1);
        StageButtonChangeColor(2, isStage2);
        StageButtonChangeColor(3, isStage3);
        StageButtonChangeColor(4, isStage4);

        _button1Image.color = new Color(red1, green1, blue1, alpha1);
        _button2Image.color = new Color(red2, green2, blue2, alpha2);
        _button3Image.color = new Color(red3, green3, blue3, alpha3);
        _button4Image.color = new Color(red4, green4, blue4, alpha4);

        //DialogText.text = dialogText;
        NoButton.SetActive(false);  // ボタンを隠す
        GoButton.SetActive(false);
        //StartCoroutine(TypeDisplay());
    }
    void Update()
    {
        // SelectPanelが出ていなくても使えるので廃止
        //if (Input.GetKey(KeyCode.Space)) // スペースキーが押されたら
        //{
        //    StopAllCoroutines();
        //    //DialogText.text = dialogText;  // DialogText.text関数にdialogText変数の中身を代入
        //    DialogText.text = "";
        //    foreach (char item in dialogText)
        //    {
        //        if (item == '|')
        //        {
        //            // <br>をDialogText.textに代入する
        //            DialogText.text += "<br>";
        //        }
        //        else
        //        {
        //            DialogText.text += item;  // 
        //        }
        //    }
        //    NoButton.SetActive(true);  // ボタンを表示
        //    GoButton.SetActive(true);
        //}
    }

    public void PushButton(int number)
    {
        // valueは今まででクリアしたステージの最高値
        int value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        // numとvalを比べて行けないならreturn どっかにボタンの色変える処理も作りたい
        // GameObject取って
        bool isPossible = true;
        switch (number)
        {
            case 1:
                _selectPanelImage.sprite = _selectPanelSprite1;
                // falseなら
                if (!isStage1) isPossible = false;
                break;

            case 2:
                _selectPanelImage.sprite = _selectPanelSprite2;
                if (!isStage2) isPossible = false;
                break;

            case 3:
                _selectPanelImage.sprite = _selectPanelSprite3;
                if (!isStage3) isPossible = false;
                break;

            case 4:
                _selectPanelImage.sprite = _selectPanelSprite4;
                if (!isStage4) isPossible = false;
                break;
        }

        if (isPossible)
        {
            _positiveSe.Play();
        }
        else
        {
            _negativeSe.Play();
            return;
        }

        // クラス名.変数名 直接代入しちゃってる
        LoadingScene.stageNum = number;  // ボタン側からステージ数を取得

        // OnSelectPressed()を実行し成功しなかったらreturn
        if (!(_stageSelect.OnSelectPressed(number))) return;

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

    private void StageButtonChangeColor(int stage, bool isChange)
    {
        Debug.Log($"s{stage},{isChange}");
        switch (stage)
        {
            case 1:
                if (isChange)
                {
                    // 行くことが可能なら
                    // 変更しない
                    red1 = kDefaultColor;
                    green1 = kDefaultColor;
                    blue1 = kDefaultColor;
                }
                else
                {
                    // 行くことが可能でないなら
                    // 変更する
                    red1 = kStopColor;
                    green1 = kStopColor;
                    blue1 = kStopColor;
                }
                break;

            case 2:
                if (isChange)
                {
                    // 変更しない
                    red2 = kDefaultColor;
                    green2 = kDefaultColor;
                    blue2 = kDefaultColor;
                }
                else
                {
                    // 変更する
                    red2 = kStopColor;
                    green2 = kStopColor;
                    blue2 = kStopColor;
                }
                break;

            case 3:
                if (isChange)
                {
                    // 変更しない
                    red3 = kDefaultColor;
                    green3 = kDefaultColor;
                    blue3 = kDefaultColor;
                }
                else
                {
                    // 変更する
                    red3 = kStopColor;
                    green3 = kStopColor;
                    blue3 = kStopColor;
                }
                break;

            case 4:
                if (isChange)
                {
                    // 変更しない
                    red4 = kDefaultColor;
                    green4 = kDefaultColor;
                    blue4 = kDefaultColor;
                }
                else
                {
                    // 変更する
                    red4 = kStopColor;
                    green4 = kStopColor;
                    blue4 = kStopColor;
                }
                break;
        }
        
    }
}