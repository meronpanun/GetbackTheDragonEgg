using DragonRace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectManager : MonoBehaviour
{
    bool isMemberSelect;
    //上がture 下がfalse
    bool isBeforeSelect1;
    bool isBeforeSelect2;
    bool isNowSelect;
    public GameObject managerMember1;
    public GameObject managerMember2;

    private StageSceneManager stageSceneManager;

    bool isStage1;
    bool isStage2;
    bool isStage3;
    bool isStage4;
    races maxRace;
    // Start is called before the first frame update
    void Start()
    {
        isMemberSelect = false;
        isBeforeSelect1 = false;
        isBeforeSelect2 = false;
        isNowSelect = false;//メンバー1を選んでるときfalse　の２はture

        //trueはクリアを意味する
        isStage1 = true;
        isStage2 = true;
        isStage3 = true;
        isStage4 = true;
        maxRace = races.none;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isNowSelect);
        if (!isMemberSelect)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown("joystick button 6"))
            {
                SelectDragonManager1.selectDragonNum1++;
                isBeforeSelect1 = false;
                isNowSelect = false;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown("joystick button 4"))
            {
                SelectDragonManager1.selectDragonNum1--;
                isBeforeSelect1 = true;
                isNowSelect = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("joystick button 7"))
            {
                SelectDragonManager2.selectDragonNum2++;
                isBeforeSelect2 = false;
                isNowSelect = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("joystick button 5"))
            {
                SelectDragonManager2.selectDragonNum2--;
                isBeforeSelect2 = true;
                isNowSelect = true;
            }
           
        }

        //Prefas使ってやりたい
        //ステージ１をクリアしたらアイスドラゴンまでを解放
        if(isStage1)
        {
            maxRace = races.ice;//ファイアーとアイスが使用可能になる
        }
        //ステージ2をクリアしたらサンダードラゴンまでを解放
        if (isStage2)
        {
            maxRace = races.thunder;//ウィンドとサンダーが使用可能になる
        }
       

        if (SelectDragonManager1.selectDragonNum1 < races.none)
        {
            SelectDragonManager1.selectDragonNum1 = maxRace;
        }
        if (SelectDragonManager1.selectDragonNum1 > maxRace)
        {
            SelectDragonManager1.selectDragonNum1 = races.none;
        }
        //メンバー２がメンバー１と同じドラゴンを選択した際に飛ばす
        if (SelectDragonManager2.selectDragonNum2 < races.none)
        {
            SelectDragonManager2.selectDragonNum2 = maxRace;
        }
        if (SelectDragonManager2.selectDragonNum2 > maxRace)
        {
            SelectDragonManager2.selectDragonNum2 = races.none;
        }




        if ((SelectDragonManager1.selectDragonNum1 == SelectDragonManager2.selectDragonNum2))
        {
             if(SelectDragonManager1.selectDragonNum1 == races.none && SelectDragonManager2.selectDragonNum2 == races.none)
            {
                return;
            }
            if (isStage3)
            {
                if ((SelectDragonManager1.selectDragonNum1 == races.fire && SelectDragonManager2.selectDragonNum2 == races.fire) || (SelectDragonManager1.selectDragonNum1 == races.ice && SelectDragonManager2.selectDragonNum2 == races.ice))
                {
                    return;
                }
            }
            if (isStage4)
            {
                if ((SelectDragonManager1.selectDragonNum1 == races.wind && SelectDragonManager2.selectDragonNum2 == races.wind) || (SelectDragonManager1.selectDragonNum1 == races.thunder && SelectDragonManager2.selectDragonNum2 == races.thunder))
                {
                    return;
                }
            }
            
            {
                if (isNowSelect == false)
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

    public void SerectMenber()
    {
        Debug.Log("メンバー決定！！！");
        Debug.Log($"左{SelectDragonManager1.selectDragonNum1},右{SelectDragonManager2.selectDragonNum2}");
        isMemberSelect = true;

        BattleTeam.sChildDragonDataLeft = SelectDragonManager1.selectDragonNum1;
        BattleTeam.sChildDragonDataRight = SelectDragonManager2.selectDragonNum2;

        Debug.Log(BattleTeam.sChildDragonDataLeft);
        Debug.Log(BattleTeam.sChildDragonDataRight);
    }

    public void BackScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
