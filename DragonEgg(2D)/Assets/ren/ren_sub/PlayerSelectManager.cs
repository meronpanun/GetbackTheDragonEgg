using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;

public class PlayerSelectManager : MonoBehaviour
{
    bool isMemberSelect;
    //上がture 下がfalse
    bool isBeforeSelect1;
    bool isBeforeSelect2;
    bool isNowSelect;
    public GameObject managerMember1;
    public GameObject managerMember2;
    // Start is called before the first frame update
    void Start()
    {
        isMemberSelect = false;
        isBeforeSelect1 = false;
        isBeforeSelect2 = false;
        isNowSelect = false;//メンバー1を選んでるときfalse　の２はture
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isNowSelect);
        if (!isMemberSelect)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SelectDragonManager1.selectDragonNum1++;
                isBeforeSelect1 = false;
                isNowSelect = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                SelectDragonManager1.selectDragonNum1--;
                isBeforeSelect1 = true;
                isNowSelect = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectDragonManager2.selectDragonNum2++;
                isBeforeSelect2 = false;
                isNowSelect = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SelectDragonManager2.selectDragonNum2--;
                isBeforeSelect2 = true;
                isNowSelect = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("メンバー決定！！！");
                isMemberSelect = true;

                //BattleTeam.sChildDragonDataLeft = SelectDragonManager1.selectDragonNum1;
                //BattleTeam.sChildDragonDataRight = SelectDragonManager2.selectDragonNum2;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("やっぱ選びなおすわ");
                isMemberSelect = false;
            }
        }

        //メンバー１がメンバー２と同じドラゴンを選択した際に飛ばす
        if (SelectDragonManager1.selectDragonNum1 == races.none)
        {
            SelectDragonManager1.selectDragonNum1 = races.fire;
        }
        if (SelectDragonManager1.selectDragonNum1 == races.player)
        {
            SelectDragonManager1.selectDragonNum1 = races.thunder;
        }
        //メンバー２がメンバー１と同じドラゴンを選択した際に飛ばす
        if (SelectDragonManager2.selectDragonNum2 == races.none)
        {
            SelectDragonManager2.selectDragonNum2 = races.fire;
        }
        if (SelectDragonManager2.selectDragonNum2 == races.player)
        {
            SelectDragonManager2.selectDragonNum2 = races.thunder;
        }

       


        if(SelectDragonManager1.selectDragonNum1 == SelectDragonManager2.selectDragonNum2)
        {
            if(isNowSelect == false)
            {
                if (!isBeforeSelect1)
                {
                    SelectDragonManager1.selectDragonNum1++;
                }
                else
                {
                    SelectDragonManager1.selectDragonNum1--;
                }
            }
           else
            {
                if (!isBeforeSelect2)
                {
                    SelectDragonManager2.selectDragonNum2++;
                }
                else
                {
                    SelectDragonManager2.selectDragonNum2--;
                }
            }
        }

    }
}
