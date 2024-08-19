using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;

public static class BattleTeam
{
    // 三つのデータを保持
    //public static TestDragonStatus sParentDragonData;
    //public static TestDragonStatus sChildDragonDataRight;
    //public static TestDragonStatus sChildDragonDataLeft;

    // 初期値は適当にプレイヤー西都甲
    public static races sParentDragonData = races.player;
    public static races sChildDragonDataRight = races.player;
    public static races sChildDragonDataLeft = races.player;
}
