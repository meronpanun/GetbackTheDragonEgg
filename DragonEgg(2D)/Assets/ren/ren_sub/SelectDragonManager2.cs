using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;

public class SelectDragonManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireDragon;
    public GameObject iceDragon;
    public GameObject windDragon;
    public GameObject thunderDragon;
    public static races selectDragonNum2;
    //public static int selectDragonNum;
    void Start()
    {
        selectDragonNum2 = races.ice; 
    }

    public static races DragonNumber()
    {
        return selectDragonNum2;
    }

    public void FireDragon()
    {
        selectDragonNum2 = races.fire;
        fireDragon.SetActive(true);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }

    public void IceDragon()
    {
        selectDragonNum2 = races.ice;
        iceDragon.SetActive(true);
        fireDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }

    public void WindDragon()
    {
        selectDragonNum2 = races.wind;
        windDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }
    public void ThunderDragon()
    {
        selectDragonNum2 = races.thunder;
        thunderDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        switch (selectDragonNum2)
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
                Debug.Log("ƒoƒO‚Á‚Ä‚é");
                break;

        }
    }
}
