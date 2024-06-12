using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDataManager
{
    // 記録できるデータの数
    private const int DATANUMBER = 10;
    // キーの固定の文字
    private const string KEYBASE = "Dragon_";

    // ドラゴンのデータが入った型の配列を作る
    // データの0番目は親ドラゴンにしよう
    // でもこれゲーム中ずっと存在するのは無駄があるなあ。べつにいいかあ。
    static TestDragonStatus[] dragonData = new TestDragonStatus[DATANUMBER];

    // メンバ関数
    public static void LoadAllSaveData() // PlayerPlefsから全データを取得
    {
        for (int i = 0; i < DATANUMBER; i++)
        {
            // KEYBASE〇〇の形でキーを作る
            string key = KEYBASE + i.ToString();

            // TestDragonStatus型に格納
            TestDragonStatus data = new TestDragonStatus(PlayerPrefs.GetString(key));
            // 配列に保存
            dragonData[i] = data;
        }
    }
}
