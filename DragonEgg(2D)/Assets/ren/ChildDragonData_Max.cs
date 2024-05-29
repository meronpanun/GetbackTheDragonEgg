using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ChildDragonData_Max")]
public class ChildDragonData_Max : ScriptableObject
{
    [SerializeField] public int maxHp;
    [SerializeField] public int maxAttack;

    ////他のファイルから値の取得はできるが変更はできない
    public int Hp { get => maxHp; }
    public int Attack { get => maxAttack; }
}
