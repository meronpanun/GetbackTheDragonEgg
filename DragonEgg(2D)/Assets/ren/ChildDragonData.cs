using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChildDragonData", menuName = "ScriptableObjects/ChildDragonData")]
public class ChildDragonData : ScriptableObject
{
    public string Id;
    public int Hp;
    public int Attack;
    public int Exp;
}