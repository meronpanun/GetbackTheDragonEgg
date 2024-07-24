using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DragonRace;

public class LeftChildDragonController : MonoBehaviour
{
    // アニメーションを切り替える

    private TestDragonStatus myStatus;
    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        // 編成から情報を受け取る
        myStatus = BattleTeam.sChildDragonDataLeft;
        Debug.Log(myStatus);
        switch (myStatus.raceNum)
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
