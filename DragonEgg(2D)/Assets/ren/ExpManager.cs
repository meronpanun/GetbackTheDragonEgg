using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ExpManager : MonoBehaviour
{
    // エディタでアタッチ
    //[SerializeField] public ChildDragonData childDragonData;
    GameObject childDragon;
    public ChildDragonData childDragonData;
    //public ChildDragonData_Max childDragonDataMax;

    //int maxExpBar;//レベルアップに必要な量
    //int nowExpBar;
    int useExp;
    //int debug1;

   

    //int addExp = 30; //加える経験値

    public Slider slider;
    public GameObject textExp;
    public GameObject addExpPoint;
    public GameObject hpPointText;
    public GameObject atkPointText;
    public GameObject levelPointText;
    // Start is called before the first frame update
    void Start()//逆だとバグる
    {
        Application.targetFrameRate = 60;
        childDragon = GameObject.Find("ChildDragon");
        //childDragonData = childDragon.GetComponent<ChildDragonData>();
        textExp = GameObject.Find("ExpText");
        addExpPoint = GameObject.Find("AddExpPoint");
        hpPointText  = GameObject.Find("HpPoint");
        atkPointText = GameObject.Find("AtkPoint");
        levelPointText = GameObject.Find("LevelPoint");


       
    }

    //Update is called once per frame
    void Update()
    {
        textExp.GetComponent<TextMeshProUGUI>().text = "EXP  " + childDragonData.exp.ToString() + '/' + childDragonData.maxExp.ToString();//テキスト
        addExpPoint.GetComponent<TextMeshProUGUI>().text = "ADD EXP? " + '+' + useExp.ToString();
        hpPointText.GetComponent<TextMeshProUGUI>().text = childDragonData.hp.ToString();
        atkPointText .GetComponent<TextMeshProUGUI>().text = childDragonData.attack.ToString();
        levelPointText .GetComponent<TextMeshProUGUI>().text = childDragonData.Level.ToString();
        

        if (Input.GetKey(KeyCode.RightArrow) && childDragonData.Level != 100)
        {
            useExp = useExp + 10;
            Debug.Log(useExp);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && childDragonData.Level != 100)
        {
            useExp = useExp - 10;
            Debug.Log(useExp);
            if (useExp <= 0)
            {
                useExp = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && childDragonData.Level != 100)
        {
            expManager(useExp);
            useExp = 0;
        }

        slider.maxValue = childDragonData.maxExp;//maxExp;
        slider.value = childDragonData.exp;
        if(childDragonData.Level >= 100)
        {
            slider.maxValue = childDragonData.maxExp;//maxExp;
            slider.value = childDragonData.maxExp;
        }
    }
    (int, int) expManager(int getExp) //タプル
    {
        childDragonData.exp += getExp;
        while(childDragonData.exp > childDragonData.maxExp)
        {
            if (childDragonData.maxExp <= childDragonData.exp && childDragonData.Level != 100)
            {
                childDragonData.exp -= childDragonData.maxExp;
                childDragonData.maxExp = (int)(childDragonData.maxExp * 1.1f);
                childDragonData.Level++;
                childDragonData.attack = Attack();
                childDragonData.hp = Hp();
            }
            else if (childDragonData.Level >= 100)
            {
                childDragonData.maxExp = (int)(childDragonData.maxExp * 1.1f);
                childDragonData.exp = childDragonData.maxExp;
                childDragonData.Level = 100;
                childDragonData.attack = Attack();
                childDragonData.hp = Hp();
            }
        }
       

        return (childDragonData.exp, childDragonData.maxExp);
    }
    int Attack()
    {
       // childDragonData.attack = childDragonData.dafaultAttack + (int)(childDragonDataMax.maxAttack * childDragonData.Level) / 100;
        childDragonData.attack += Random.Range(1, 5);
        //保存
        PlayerPrefs.SetFloat("Hp", childDragonData.hp);
        return childDragonData.attack;
    }
    int Hp()
    {
       // childDragonData.hp = childDragonData.dafaultHp + (int)(childDragonDataMax.maxHp * childDragonData.Level) / 100;
        childDragonData.hp += Random.Range(1, 5);
        //保存
        PlayerPrefs.SetInt("Attack", childDragonData.attack);
        return childDragonData.hp;
    }
}
