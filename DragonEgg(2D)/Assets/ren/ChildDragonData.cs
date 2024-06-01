using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(menuName = "ChildDragonData")]

public class ChildDragonData :MonoBehaviour
{
    [SerializeField] public int hp;
    [SerializeField] public int attack;
    //[SerializeField] public int dafaultHp = 100;
    //[SerializeField] public int dafaultAttack = 10;
    [SerializeField] float speed = 0.1f;
    [SerializeField] public int exp;
    [SerializeField] public int maxExp;
    [SerializeField] string childDragonName;
    [SerializeField] public int Level;
    [SerializeField] public int ID;
}
