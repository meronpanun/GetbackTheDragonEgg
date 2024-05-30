// 表示+徐々に文字が表示される+
// メッセージが全て表示されたらボタン表示+
// スペースキーを押すとメッセージを即全部表示
using System.Collections;
using UnityEngine;
using TMPro;
public class DialogBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject _noButton;
    [SerializeField] private GameObject _goButton;
    [TextArea(5, 5)]
    //[SerializeField] private string msgText;  // 使わなくなった
    private float msgSpeed = 0.07f;  // テキスト表示間隔

    //int stageNum = 0;
    string dialogText = "";  // 非同期処理のforeach文の指定でつっかえたので変数を作って解決させた

    void Start()
    {
        //DialogText.text = dialogText;
        _noButton.SetActive(false);  // ボタンを隠す
        _goButton.SetActive(false);
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
            _noButton.SetActive(true);  // ボタンを表示
            _goButton.SetActive(true);
        }
    }

    public void Push_Button(int number)
    {
        // クラス名.変数名
        LoadingScene.stageNum = number;  // ボタン側からステージ数を取得
        DialogText.text = "";
        dialogText = "Stage " + LoadingScene.stageNum + "||Ready?";  // dialogText変数に文を代入
        StartCoroutine(TypeDisplay());  // メッセージ表示を開始
        
        Debug.Log("Stage " + LoadingScene.stageNum + "||Ready?");
        Debug.Log(DialogText.text);
    }

    IEnumerator TypeDisplay()  // メッセージを表示させる機構？ IEnumeratorは非同期処理を行うために用いるデータ型の一種
    {
        foreach (char item in dialogText)
        {
            if(item == '|')
            {
                // <br>をDialogText.textに代入する
                DialogText.text += "<br>";
            }
            else
            {
                DialogText.text += item;  // 
            }

            
            yield return new WaitForSeconds(msgSpeed);  // メッセージをmsgSpeed毎に表示？
        }
        _noButton.SetActive(true);  // ボタンを表示
        _goButton.SetActive(true);
    }
}