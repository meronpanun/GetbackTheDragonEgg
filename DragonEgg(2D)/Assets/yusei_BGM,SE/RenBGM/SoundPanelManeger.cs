using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManeger : MonoBehaviour
{
    //表示したいUIパネル
    public GameObject pousePanel;
    public GameObject SoundPanel;

    //初期選択ボタン
    public GameObject pouseFirstbutton;
    public GameObject SoundFirstbutton;

    //ポーズメニューに切り替え
    public void SelectedPouseMenu()
    {
        //初期選択ボタンの初期化
        EventSystem.current.SetSelectedGameObject(null);
        //初期選択ボタンの再指定
        EventSystem.current.SetSelectedGameObject(pouseFirstbutton);

        pousePanel.SetActive(true);
        SoundPanel.SetActive(false);
    }

    //サウンドメニューに切り替え
    public void SelectedSoundMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(SoundFirstbutton);

        pousePanel.SetActive(false);
        SoundPanel.SetActive(true);
    }
}
