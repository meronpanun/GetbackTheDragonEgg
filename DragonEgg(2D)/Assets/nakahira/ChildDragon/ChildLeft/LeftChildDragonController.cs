using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DragonRace;

public class LeftChildDragonController : MonoBehaviour
{
    // アニメーションを切り替える

    private races myRace;
    private Animator myAnimator;
    // IDragonBulletのインターフェース型の変数を宣言して
    // それに各属性の弾をStart時に入れる

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        // 編成から情報を受け取る
        // 仮でバトルチームに適当なデータを入れる
        BattleTeam.sChildDragonDataLeft = DragonRace.races.thunder;
        myRace = BattleTeam.sChildDragonDataLeft;
        Debug.Log($"種族{myRace}");
        switch (myRace)
        {
            case races.player:
                myAnimator.SetTrigger("Player");
                break;
            case races.fire:
                myAnimator.SetTrigger("Fire");
                break;
            case races.ice:
                myAnimator.SetTrigger("Ice");
                break;
            case races.wind:
                myAnimator.SetTrigger("Wind");
                break;
            case races.thunder:
                myAnimator.SetTrigger("Thunder");
                break;
            case races.none:
                myAnimator.SetTrigger("Empty");
                break;
            default:
                myAnimator.SetTrigger("Error");
                Debug.Log("Error!!");
                break;
        }
    }
}
