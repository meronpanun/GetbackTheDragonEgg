using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            case 0:
                icon.sprite = oya;
                break;
            case 1:
                icon.sprite = fire;
                break;
            case 2:
                icon.sprite = ice;
                break;
            case 3:
                icon.sprite = wind;
                break;
            case 4:
                icon.sprite = thunder;
                break; 
            case 5:
                icon.sprite = none;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
