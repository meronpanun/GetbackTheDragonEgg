using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using DragonRace;

namespace DragonRace
{
    // 列挙しとく
    public enum races
    {
        none,
        fire,
        ice,
        wind,
        thunder,
        player,
      
    }
}

public class TestDragonStatus
{
    // 現在のステータスの種類はELEMENTS種類。
    private const int ELEMENTS = 7;
    // 区切りに使用される文字
    private const char INDEXWORD = ',';

    public TestDragonStatus()
    {
        // 引数なしは何もしない
    }
    public TestDragonStatus(string data)
    {
        //データ調べる
        if(data == "")
        {
            raceNum = races.none;
            Debug.Log($"NULL{raceNum}");
        }
        else
        {
            // 要素数(区切り文字の数)をチェック
            CheckElements(data);
            // それぞれの変数に値を代入
            AssignmentStatus(data);
            // これらは一つにまとめられるかも
            // 確認
            Debug.Log($"{raceNum}, {hp}, {attack}, {speed}, {level}, {nowExp}, {name}");
        }
    }

    // メンバ変数



    enum status
    {
        raceNum,
        hp,
        attack,
        speed,
        level,
        nowExp,
        name, // こいつだけstringなのよ
    }

    // こいつがどの種類のドラゴンなのか
    public races raceNum;

    // 体力。プレイヤーに加算する予定
    public int hp;

    // 攻撃力。これを弾の基礎値に掛け算するつもり
    public int attack;

    // 移動スピード
    public float speed;

    // 現在レベル
    public int level;

    // 現在の経験値
    public int nowExp;

    // 名前。できたら
    public string name;

    // 現在のデータをstring一行で返す処理をプロパティで実装
    public string dataString
    {
        get
        {
            // これクソコードじゃん
            // 返す値
            StringBuilder value = new StringBuilder();
            value.Append(raceNum.ToString());
            value.Append(INDEXWORD);
            value.Append(hp.ToString());
            value.Append(INDEXWORD);
            value.Append(attack.ToString());
            value.Append(INDEXWORD);
            value.Append(speed.ToString());
            value.Append(INDEXWORD);
            value.Append(level.ToString());
            value.Append(INDEXWORD);
            value.Append(nowExp.ToString());
            value.Append(INDEXWORD);
            value.Append(name); // nameはstringですが
            return value.ToString(); // 扱う型をそもそもStringBuilderにしたほうがいいかなあ
                                     // とも思ったけどPlayerPlefsがstringしか受け付けないわ
        }
    }

    // レベルから現在必要経験値を割り出すプロパティ
    public int nextExp
    {
        get
        {
            // リテラル。あとで何とかしよう
            float result = 10f;
            // level分繰り返す
            for (int i = 0; i < level; i++)
            {
                result *= 1.07f;
            }
            return (int)result;
        }
    }

    // メンバ関数

    // 長いのでコンストラクタから退避
    private void CheckElements(string data)
    {
        // とりあえず与えられたデータの要素数が想定どおりなのか確認
        int elementCount = 1;
        // 文字列の中で既定の区切り文字を探す
        foreach (char c in data)
        {
            // あったら
            if (c == INDEXWORD)
            {
                elementCount++;
            }
        }
        if (elementCount != ELEMENTS) // 正しい要素数でなければ
        {
            throw new Exception("要素数おかしくない？");
        }
        else
        {
            Debug.Log("要素数おっけー");
        }
    }

    // 長いので退避その2
    private void AssignmentStatus(string data)
    {
        // 属性の番地(1~7)
        status elementNumber = status.raceNum;
        // 取り出した値を一時保存
        string value = "";
        // データの取り出し
        foreach (char c in data)
        {
            // 読んだ文字が区切り文字でないなら
            if (c != INDEXWORD)
            {
                // 読み込んでいくぅ
                value = value + c;
            }
            // でなければ
            else
            {
                Debug.Log(value);
                Debug.Log(elementNumber);
                // 今やっているステータスに代入(ネストすげえ)
                // 各ステータスもクラス化してインターフェースとかで
                // つなげれねえかな
                // ステータスを配列にしたら解決しそうだけど
                // あんまり順番を設定したくない（列挙してるけど）
                // でも順番を設定しないと繰り返し処理で実装できないんだよなあ　
                switch (elementNumber)
                {
                    // キャストバグったら勝手にエラー吐くでしょう
                    case status.raceNum:
                        // 列挙型に型変換
                        raceNum = (races)int.Parse(value);
                        break;
                    case status.hp:
                        hp = int.Parse(value);
                        break;
                    case status.attack:
                        attack = int.Parse(value);
                        break;
                    case status.speed:
                        speed = int.Parse(value);
                        break;
                    case status.level:
                        level = int.Parse(value);
                        break;
                    case status.nowExp:
                        nowExp = int.Parse(value);
                        break;
                    case status.name:
                        name = value;
                        break;
                    default:
                        throw new Exception("おいおい、elementNumberがおかしいぜ");
                }
                // 次のステータスへ
                elementNumber++;
                // 値もリセット
                value = "";
            }
        }
    }
}
