using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonRace;

public class DragonIconData : MonoBehaviour
{
    public TestDragonStatus dragonStatus;
    private Image icon;
    // エディタ
    public Sprite oya;
    public Sprite fire;
    public Sprite ice;
    public Sprite wind;
    public Sprite thunder;
    public Sprite none;


    // Start is called before the first frame update
    void Start()
    {
        icon = GetComponent<Image>();
        icon.sprite = ice;
        switch (dragonStatus.raceNum)
        {
            case races.player:
                icon.sprite = oya;
                break;
            case races.fire:
                icon.sprite = fire;
                break;
            case races.ice:
                icon.sprite = ice;
                break;
            case races.wind:
                icon.sprite = wind;
                break;
            case races.thunder:
                icon.sprite = thunder;
                break; 
            case races.none:
                icon.sprite = none;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
