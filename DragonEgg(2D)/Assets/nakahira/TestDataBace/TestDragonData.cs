//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public struct TestDragonStatus
//{
//    // 現在のステータスの種類はELEMENTS種類。
//    private const int ELEMENTS = 7;
//    // 区切りに使用される文字
//    private const char INDEXWORD = ',';

//    public TestDragonStatus(string data)
//    {
//        // 要素数(区切り文字の数)をチェック
//        CheckElements(data);
//        // それぞれの変数に値を代入
//        AssignmentStatus(data);
//        // これらは一つにまとめられるかも
//    }

//    private const int PLAYER = 0;
//    private const int FIRE = 1;
//    private const int ICE = 2;
//    private const int WIND = 3;
//    private const int THUNDER = 4;

//    // メンバ変数

//    // 列挙しとく
//    enum status
//    {
//        raceNum,
//        hp,
//        attack,
//        speed,
//        level,
//        nowExp,
//        name, // こいつだけstringなのよ
//    }

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

//    // 現在のデータをstring一行で返す処理をプロパティで実装
//    string dataString
//    {
//        get
//        {
//            // 返す値
//            string value = "";
//            value = raceNum + INDEXWORD + 
//                    hp + INDEXWORD + attack + "," + speed + "," ;
//        }
//    }


//    // メンバ関数

//    // 長いのでコンストラクタから退避
//    private void CheckElements(string data)
//    {
//        // とりあえず与えられたデータの要素数が想定どおりなのか確認
//        int elementCount = 0;
//        // 文字列の中で既定の区切り文字を探す
//        foreach (char c in data)
//        {
//            // あったら
//            if (c == INDEXWORD)
//            {
//                elementCount++;
//            }
//        }
//        if (elementCount != ELEMENTS) // 正しい要素数でなければ
//        {
//            throw new Exception("要素数おかしくない？");
//        }
//        else
//        {
//            Debug.Log("要素数おっけー");
//        }
//    }

//    // 長いので退避その2
//    private void AssignmentStatus(string data)
//    {
//        // 属性の番地(1~7)
//        status elementNumber = status.raceNum;
//        // 取り出した値を一時保存
//        string value = "";
//        // データの取り出し
//        foreach (char c in data)
//        {
//            // 読んだ文字が区切り文字でないなら
//            if (c != INDEXWORD)
//            {
//                // 読み込んでいくぅ
//                value = value + c;
//            }
//            // でなければ
//            else
//            {
//                // 今やっているステータスに代入(ネストすげえ)
//                // 各ステータスもクラス化してインターフェースとかで
//                // つないだ方が絶対きれい(なのは分かってる)
//                switch (elementNumber)
//                {
//                    // キャストバグったら勝手にエラー吐くでしょう
//                    case status.raceNum:
//                        raceNum = int.Parse(value);
//                        break;
//                    case status.hp:
//                        hp = int.Parse(value);
//                        break;
//                    case status.attack:
//                        attack = int.Parse(value);
//                        break;
//                    case status.speed:
//                        speed = int.Parse(value);
//                        break;
//                    case status.nowExp:
//                        nowExp = int.Parse(value);
//                        break;
//                    case status.name:
//                        name = value;
//                        break;
//                    default:
//                        throw new Exception("おいおい、elementNumberがおかしいぜ");
//                }
//                // 次のステータスへ
//                elementNumber++;
//                // 値もリセット
//                value = "";
//            }
//        }
//    }
//}
