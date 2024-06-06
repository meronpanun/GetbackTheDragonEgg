using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TestDragonStatus
{
    private const int PLAYER = 0;
    private const int FIRE = 1;
    private const int ICE = 2;
    private const int WIND = 3;
    private const int THUNDER = 4;

    // メンバ変数

    // こいつがどの種類のドラゴンなのか
    int raceNum; 

    // 体力。プレイヤーに加算する予定
    int hp;

    // 攻撃力。これを弾の基礎値に掛け算するつもり
    int attack;

    // 移動スピード
    float speed;


}
