using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{

    //３つのPanelを格納する変数
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject SoundPanel;
    //[SerializeField] GameObject xrHubPanel;
    //[SerializeField] GameObject unityPanel;


    // Start is called before the first frame update
    void Start()
    {
        //BackToMenuメソッドを呼び出す
        BackToMenu();
    }


    //SoundPanelでOKButtonが押されたときの処理
    //XR-HubPanelをアクティブにする
    public void SelectXrHubDescription()
    {
        SoundPanel.SetActive(true);
        //.SetActive(true);
    }


    ////MenuPanelでUnityButtonが押されたときの処理
    ////UnityPanelをアクティブにする
    //public void SelectUnityDescription()
    //{
    //    menuPanel.SetActive(false);
    //    unityPanel.SetActive(true);
    //}


    //2つのDescriptionPanelでBackButtonが押されたときの処理
    //MenuPanelをアクティブにする
    public void BackToMenu()
    {
        SoundPanel.SetActive(true);
        //xrHubPanel.SetActive(false);
        //unityPanel.SetActive(false);
    }
}
