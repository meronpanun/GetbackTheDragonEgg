using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;

public class SelectDragonManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireDragon;
    public GameObject iceDragon;
    public GameObject windDragon;
    public GameObject thunderDragon;
    public static races selectDragonNum1;
    //public static int selectDragonNum;
    void Start()
    {
        selectDragonNum1 = races.fire;//最初は何も表示したくないので、割り当てをしていない番号を代入します
    }

    public static races DragonNumber()
    {
        return selectDragonNum1;
    }

    public void FireDragon()
    {
        selectDragonNum1 = races.fire;
        fireDragon.SetActive(true);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }

    public void IceDragon()
    {
        selectDragonNum1 = races.ice;
        iceDragon.SetActive(true);
        fireDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }

    public void WindDragon()
    {
        selectDragonNum1 = races.wind;
        windDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }
    public void ThunderDragon()
    {
        selectDragonNum1 = races.thunder;
        thunderDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (selectDragonNum1)
        {
            case races.fire:
                FireDragon();
                break;
            case races.ice:
                IceDragon();
                break;
            case races.wind:
                WindDragon();
                break;
            case races.thunder:
                ThunderDragon();
                break;
            default:
                Debug.Log("バグってる");
                break;

        }
    }
}
