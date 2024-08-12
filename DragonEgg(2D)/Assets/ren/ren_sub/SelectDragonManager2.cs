using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;
using TMPro;

public class SelectDragonManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject noneDragon;
    public GameObject fireDragon;
    public GameObject iceDragon;
    public GameObject windDragon;
    public GameObject thunderDragon;
    public static races selectDragonNum2;
    private GameObject objMemberText;
    private TextMeshProUGUI memberText;

    void Start()
    {
        selectDragonNum2 = races.none;
        objMemberText = GameObject.Find("Canvas/member2/member2text");
        memberText = objMemberText.GetComponent<TextMeshProUGUI>();
    }

    public static races DragonNumber()
    {
        return selectDragonNum2;
    }

    public void NoneDragon()
    {
        selectDragonNum2 = races.none;
        noneDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
        memberText.text = "None";
        memberText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void FireDragon()
    {
        selectDragonNum2 = races.fire;
        fireDragon.SetActive(true);
        noneDragon.SetActive(false);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
        memberText.text = "Fire";
        memberText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }

    public void IceDragon()
    {
        selectDragonNum2 = races.ice;
        iceDragon.SetActive(true);
        noneDragon.SetActive(false);
        fireDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
        memberText.text = "Ice";
        memberText.color = new Color(0.0f, 0.5f, 1.0f, 1.0f);
    }

    public void WindDragon()
    {
        selectDragonNum2 = races.wind;
        windDragon.SetActive(true);
        noneDragon.SetActive(false);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        thunderDragon.SetActive(false);
        memberText.text = "Wind";
        memberText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    }
    public void ThunderDragon()
    {
        selectDragonNum2 = races.thunder;
        thunderDragon.SetActive(true);
        noneDragon.SetActive(false);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
        memberText.text = "Thunder";
        memberText.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        switch (selectDragonNum2)
        {
            case races.none:
                NoneDragon();
                break;
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
