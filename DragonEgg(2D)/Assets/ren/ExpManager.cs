using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ExpManager : MonoBehaviour
{
    // エディタでアタッチ
    //[SerializeField] public ChildDragonData childDragonData;
    GameObject FireDragon;

    int maxExpBar;//レベルアップに必要な量
    int nowExpBar;
    //int addExp = 30; //加える経験値

    public Slider slider;
    // Start is called before the first frame update
    void Start()//逆だとバグる
    {
        FireDragon = GameObject.Find("FireDragon");
    }

    //Update is called once per frame
    void Update()
    {

        slider.maxValue = FireDragon.GetComponent<childDragonStats>().maxExp;//maxExp;
        slider.value = FireDragon.GetComponent<childDragonStats>().exp;
    }

}
