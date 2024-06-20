using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCastom : MonoBehaviour
{
    //player,
    //fire,
    //ice,
    //wind,
    //thunder,
    //none
    public enum racesTest
    {
        player,
        fire,
        ice,
        wind,
        thunder,
        none
    }
    //スロットにモンスターを入れる
    public racesTest Type;

    public void SelectThis()
    {
        gameObject.SetActive(false);
    }
}
