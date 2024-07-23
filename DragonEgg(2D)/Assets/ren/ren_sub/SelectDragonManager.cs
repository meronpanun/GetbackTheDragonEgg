using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDragonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireDragon;
    public GameObject iceDragon;
    public GameObject windDragon;
    public static int selectDragonNum;
    void Start()
    {
        selectDragonNum = 0;//最初は何も表示したくないので、割り当てをしていない番号を代入します
    }

    public static int DragonNumber()
    {
        return selectDragonNum;
    }

    public void FireDragon()
    {
        selectDragonNum = 0;
        fireDragon.SetActive(true);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
    }

    public void IceDragon()
    {
        selectDragonNum = 1;
        iceDragon.SetActive(true);
        fireDragon.SetActive(false);
        windDragon.SetActive(false);
    }

    public void WindDragon()
    {
        selectDragonNum = 2;
        windDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectDragonNum++;
        }

        if(selectDragonNum >= 3)
        {
            selectDragonNum = 0;
        }

        switch(selectDragonNum)
        {
            case 0:
                FireDragon();
                break;
            case 1:
                IceDragon();
                break;
            case 2:
                WindDragon();
                break;
            default:
                Debug.Log("バグってる");
                break;

        }
    }
}
