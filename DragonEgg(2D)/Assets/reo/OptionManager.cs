using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionManager : MonoBehaviour
{
    private EventSystem _eventSystem;

    [SerializeField] private AudioSource _negativeSe;
    [SerializeField] private AudioSource _positiveSe;

    [SerializeField] private TextMeshProUGUI _dialogText;

    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private GameObject _seButton;
    [SerializeField] private GameObject _noButton;
    [SerializeField] private GameObject _goButton;

    [SerializeField] private FadeManager fadeManager;

    private const float kMsgSpeed = 0.09f;
    private string dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        _eventSystem = EventSystem.current;

        _eventSystem.SetSelectedGameObject(_seButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickTitleButton()
    {
        _positiveSe.Play();

        _dialogText.text = "";
        dialogText = "|Back to Title?";
        StartCoroutine(ScaleChange());
    }

    IEnumerator ScaleChange()
    {
        _noButton.SetActive(false);
        _goButton.SetActive(false);
        _dialogPanel.SetActive(true);

        // 徐々に大きくする
        for (int i = 0; i < 10; i++)
        {
            _dialogPanel.transform.localScale = new Vector3(i / 10f, i / 10f, 1);
            yield return new WaitForSeconds(0.06f);
        }
        // scaleを1にする(保険)
        _dialogPanel.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(TypeDisplay());  // メッセージ表示を開始
    }

    IEnumerator TypeDisplay()
    {
        _noButton.SetActive(false);
        _goButton.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>をDialogText.textに代入する
                _dialogText.text += "<br>";
                yield return 0;
            }
            else
            {
                _dialogText.text += item;
            }

            // 文字をkMsgSpeed毎に表示
            yield return new WaitForSeconds(kMsgSpeed);
        }
        _noButton.SetActive(true);
        _goButton.SetActive(true);
        _eventSystem.SetSelectedGameObject(_noButton);
    }

    public void OnclickNoButton()
    {
        _negativeSe.Play();
        _dialogPanel.SetActive(false);
        _eventSystem.SetSelectedGameObject(_seButton);
    }

    public void OnclickGoButton()
    {
        _positiveSe.Play();
        fadeManager.FadeOutSwitch(0);
    }
}
