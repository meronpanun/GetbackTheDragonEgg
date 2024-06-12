using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleTeam", menuName = "ScriptableObjects/CreateBattleTeam")]
public class BattleTeam : ScriptableObject
{
    // バトルに出る親と左右のドラゴンのデータを保持
    public TestDragonStatus ParentDragon;
    public TestDragonStatus DhildDragonRight;
    public TestDragonStatus DhildDragonLeft;
}
