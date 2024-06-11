using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene切り替えを行うため

// フェードイン、フェードアウト管理スクリプト

public class TestFade1Manager : MonoBehaviour
{
    float Speed = 0.001f;        //フェードするスピード、多いと早くフェードする
    float red, green, blue, alfa;
    string loadScene = "TestErrorScene";

    public bool Out = false;
    public bool In = false;

    Image fadeImage;                //パネル

    // このスクリプトを使う際は
    // ・パネルのImageのチェックボックスを切る
    // ・パネルのalfaを255に設定
    // ・シーン移行するボタンから FadeOutSwitch(int number) を送るように設定する;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        FadeInSwitch();
    }

    void Update()
    {
        

        if (In)
        {
            FadeIn();
        }

        if (Out)
        {
            FadeOut();
        }
    }
    public void FadeInSwitch()
    {
        fadeImage.enabled = true;
        In = true;
    }

    public void FadeOutSwitch(int number)  // ボタンから受け取った数字を照らし合わせる
    {
        if (number != 0)
        {
            LoadingScene.stageNum = number;
        }

        switch (LoadingScene.stageNum)  // シーン切り替え
        {
            case 100:
                loadScene = "TestStageSelectScene";
                break;

            //case 1:
            //    loadScene = "TestStage1";
            case 1:
                loadScene = "Battle";
                break;
            case 2:
                loadScene = "TestStage2";
                break;
            case 3:
                loadScene = "TestStage3";
                break;
            case 4:
                loadScene = "TestStage4";
                break;

            case 11:
                loadScene = "TestFade1";
                break;
            case 12:
                loadScene = "TestFade2";
                break;

            default:
                loadScene = "TestErrorScene";
                break;


        }

        alfa = 0;
        //fadeImage.enabled = true;
        Out = true;
    }

    void FadeIn()
    {
        alfa -= Speed;
        Alpha();
        if (alfa <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        alfa += Speed;
        Alpha();
        if (alfa >= 1)
        {
            Out = false;
            SceneManager.LoadSceneAsync(loadScene);
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
