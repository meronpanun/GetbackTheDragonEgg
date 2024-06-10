//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public struct TestDragonStatus
//{

//    private const int ELEMENTS = 7;
//    public TestDragonStatus(string data)
//    {
//        // とりあえず与えられたデータが想定どおりなのか確認
//        string indexWord = ",";
//        int foundIndex = 0;
//        int elementCount = 0;
//        do
//        {
//            elementCount++;
//            foundIndex = data.IndexOf(indexWord);
//        } while (foundIndex > 0);
//        if (elementCount != ELEMENTS) // 正しい要素数でなければ
//        {

//        }
        
//    }

//    private const int PLAYER = 0;
//    private const int FIRE = 1;
//    private const int ICE = 2;
//    private const int WIND = 3;
//    private const int THUNDER = 4;

//    // メンバ変数

//    // こいつがどの種類のドラゴンなのか
//    int raceNum; 

//    // 体力。プレイヤーに加算する予定
//    int hp;

//    // 攻撃力。これを弾の基礎値に掛け算するつもり
//    int attack;

//    // 移動スピード
//    float speed;

//    // 名前。できたら
//    string name;

//    // 現在レベル
//    int level;

//    // 現在の経験値
//    int nowExp;
//}
