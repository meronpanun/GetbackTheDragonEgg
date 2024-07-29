using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;
using TMPro;

public class SelectDragonManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireDragon;
    public GameObject iceDragon;
    public GameObject windDragon;
    public GameObject thunderDragon;
    public static races selectDragonNum1;
    private GameObject objMemberText;
    private TextMeshProUGUI memberText;



    void Start()
    {
        selectDragonNum1 = races.fire;
        objMemberText = GameObject.Find("Canvas/member1/member1text");
        memberText = objMemberText.GetComponent<TextMeshProUGUI>();

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
        memberText.text = "Fire";
        memberText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }

    public void IceDragon()
    {
        selectDragonNum1 = races.ice;
        iceDragon.SetActive(true);
        fireDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
        memberText.text = "Ice";
        memberText.color = new Color(0.0f, 0.5f, 1.0f, 1.0f);
    }

    public void WindDragon()
    {
        selectDragonNum1 = races.wind;
        windDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        thunderDragon.SetActive(false);
        memberText.text = "Wind";
        memberText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    }
    public void ThunderDragon()
    {
        selectDragonNum1 = races.thunder;
        thunderDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
        memberText.text = "Thunder";
        memberText.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
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
                break;

        }
    }
}
