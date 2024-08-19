using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene切り替えを行うため
using UnityEngine.EventSystems;

// フェードイン、フェードアウト管理スクリプト

public class FadeManager : MonoBehaviour
{
    float time = 0.0f;
    float fadeSpeed = 1.0f;        //フェードする速度 秒
    float red, green, blue, alpha;  //alfaくらいしか使わない
    string loadScene = "TestErrorScene";  // ロードするシーンの名前
    

    // フェードイン、フェードアウトを管理するスイッチ
    public bool Out = false;
    public bool In = false;

    // フェード中か否か
    public bool isFade = false;

    Image fadeImage;    //パネル

    // このスクリプトを使う際は
    // ・パネルのImageのチェックボックスを切る
    // ・パネルのalfaを255に設定
    // ・シーン移行するボタンから FadeOutSwitch(int number) を送るように設定する

    void Start()
    {
       
        // パネルの色、不透明度情報
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;

        // シーンが読み込まれたときにフェードイン処理
        FadeInSwitch();
    }

    void Update()
    {
        //Debug.Log(StageLoadSceneData.stageLoadScene);
        // スイッチがオンになっているならそれぞれの処理
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
        time = 0;
        fadeImage.enabled = true;
        In = true;
        isFade = true;
    }

    public void FadeOutSwitch(int number)  // ボタンから受け取った数字を照らし合わせる
    {
        if (number != 0)
        {
            LoadingScene.stageNum = number;

            Debug.Log($"Fade:{number}");
        }

        //// コントローラー対応
        //if (0 < Input.GetAxisRaw("Vertical"))
        //{
        //    // 選択中のオブジェクト取得
        //    GameObject nowObj = EventSystem.current.currentSelectedGameObject;
        //}

        switch (LoadingScene.stageNum)  // シーン切り替え
        {
            //case 100:
            //    loadScene = "TestStageSelectScene";
            //    break;
            case 0:
                loadScene = "TitleScene";
                break;
            case 100:
                loadScene = "StageSelectScene";
                break;
            case 101:
                loadScene = "HomeScene";
                break;

            //case 102:
            //    loadScene = "ReinforcementScene";  // "ren"
            //    break;
            case 103:
                loadScene = "OptionScene";
                break;
            case 104:
                loadScene = "CreditScene";
                break;


            //case 1:
            //    loadScene = "TestStage1";
            case 1:
                loadScene = "PartySelectScene";
                //StageLoadSceneData.stageLoadScene = "Battle";
                StageLoadSceneData.stageLoadScene = "Battle1";
                break;
            case 2:
                loadScene = "PartySelectScene";
                //StageLoadSceneData.stageLoadScene = "TestStage2";
                StageLoadSceneData.stageLoadScene = "Battle2";
                break;
            case 3:
                loadScene = "PartySelectScene";
                StageLoadSceneData.stageLoadScene = "Battle3";
                break;
            case 4:
                loadScene = "PartySelectScene";
                StageLoadSceneData.stageLoadScene = "Battle4";
                break;

            //case 11:
            //    loadScene = "TestFade1";
            //    break;
            //case 12:
            //    loadScene = "TestFade2";
            //    break;

            case 10:
                loadScene = "FailScene";
                break;

            case 11:
                loadScene = "ClearScene1";
                break;
            case 12:
                loadScene = "ClearScene2";
                break;
            case 13:
                loadScene = "ClearScene3";
                break;
            case 14:
                loadScene = "ClearScene4";
                break;
            

            default:
                loadScene = "TestErrorScene";
                break;


        }

        // 不透明度を0(透明)にし、フェードアウト処理開始
        alpha = 0;
        time = 0;
        Out = true;
        isFade = true;
    }

    private void FadeIn()    // フェードイン処理
    {
        // 不透明度をfadeSpeedずつ減らす
        //alpha -= fadeSpeed;
        time += Time.deltaTime;
        alpha = 1.0f - time / fadeSpeed;
        //alpha -= fadeSpeed * Time.deltaTime;
        ChangeColor();
        if (alpha <= 0)
        {
            In = false;
            fadeImage.enabled = false;
            isFade = false;
        }
    }

    private void FadeOut()    // フェードアウト処理
    {
        fadeImage.enabled = true;
        // 不透明度をfadeSpeedずつ増やす
        //alpha += fadeSpeed;
        time += Time.deltaTime;
        alpha = time / fadeSpeed;
        //alpha += fadeSpeed * Time.deltaTime;
        ChangeColor();

        // 完全に不透明になったらシーン移行
        if (alpha >= 1)
        {
            Out = false;
            isFade = false;
            SceneManager.LoadScene(loadScene);
        }
    }

    // 増減処理を反映
    private void ChangeColor()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    public string GetStageLoadScene()
    {
        return StageLoadSceneData.stageLoadScene;
    }
}
