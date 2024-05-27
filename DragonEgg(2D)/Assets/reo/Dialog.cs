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
    [SerializeField] private string msgText;
    private float msgSpeed = 0.03f;  // テキスト表示間隔
    void Start()
    {
        DialogText.text = "";
        _noButton.SetActive(false);  // ボタンを隠す
        _goButton.SetActive(false);
        StartCoroutine(TypeDisplay());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // スペースキーが押されたら
        {
            StopAllCoroutines();
            DialogText.text = msgText;
            _noButton.SetActive(true);  // ボタンを表示
            _goButton.SetActive(true);
        }
    }
    IEnumerator TypeDisplay()  // メッセージを表示させる機構？ IEnumeratorは非同期処理を行うために用いるデータ型の一種
    {
        foreach (char item in msgText.ToCharArray())
        {
            DialogText.text += item;
            yield return new WaitForSeconds(msgSpeed);  // メッセージをmsgSpeed毎に表示？
        }
        _noButton.SetActive(true);  // ボタンを表示
        _goButton.SetActive(true);
    }
}