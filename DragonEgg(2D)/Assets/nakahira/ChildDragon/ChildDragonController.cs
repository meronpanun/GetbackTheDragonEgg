//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class ChildDragonController : MonoBehaviour
//{
//    [SerializeField]
//    private Animation parent;
//    [SerializeField]
//    private Animation fire;
//    [SerializeField]
//    private Animation ice;
//    [SerializeField]
//    private Animation wind;
//    [SerializeField]
//    private Animation thunder;
//    [SerializeField]
//    private Animation empty;

//    private TestDragonStatus myStatus;
//    private Animator myAnimator;

//    private void Start()
//    {
//        myAnimator = GetComponent<Animator>();
//        myAnimator.
//        // ï“ê¨Ç©ÇÁèÓïÒÇéÛÇØéÊÇÈ
//        myStatus = BattleTeam.sChildDragonDataLeft;

//        switch(myStatus.raceNum)
//        {
//            case 0:
//                myRenderer.sprite = parent;
//                break;
//            case 1:
//                myRenderer.sprite = fire;
//                break;
//            case 2:
//                myRenderer.sprite = ice;
//                break;
//            case 3:
//                myRenderer.sprite = wind;
//                break;
//            case 4:
//                myRenderer.sprite = thunder;
//                break;
//            default:
//                myRenderer.sprite = empty;
//                break;
//        }
//    }


//}
