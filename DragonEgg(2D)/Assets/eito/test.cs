using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;  // UIコンポーネントの使用
public class test : MonoBehaviour
{
    [SerializeField] Button focusButton;
    // Start is called before the first frame update
    void Start()
    {
        // ボタンコンポーネントの取得
        focusButton = focusButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //全てのフォーカスを解除する
        EventSystem.current.SetSelectedGameObject(null);
        //focusButtonにフォーカスする
        focusButton.Select();
        //Canvasコンポーネントを無効にする。Buttonコンポーネントで設定可。
    }
}
