using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ExpManager : MonoBehaviour
{
    // エディタでアタッチ
    //[SerializeField] public ChildDragonData childDragonData;
    GameObject childDragon;
    private ChildDragonData childDragonData;
    public ChildDragonData_Max childDragonDataMax;

    //int maxExpBar;//レベルアップに必要な量
    //int nowExpBar;
    int useExp;
    //int debug1;

   

    //int addExp = 30; //加える経験値

    public Slider slider;
    // Start is called before the first frame update
    void Start()//逆だとバグる
    {
        childDragon = GameObject.Find("ChildDragon");
        childDragonData = childDragon.GetComponent<ChildDragonData>();

    }

    //Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && childDragonData.Level != 100)
        {
            useExp = useExp + 10;
            Debug.Log(useExp);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && childDragonData.Level != 100)
        {
            useExp = useExp - 10;
            Debug.Log(useExp);
        }

        if (Input.GetKeyDown(KeyCode.Space) && childDragonData.Level != 100)
        {
            if (useExp <= 0)
            {
                useExp = 0;
            }
            Debug.Log(expManager(useExp));
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

        return (childDragonData.exp, childDragonData.maxExp);
    }
    int Attack()
    {
       // childDragonData.attack = childDragonData.dafaultAttack + (int)(childDragonDataMax.maxAttack * childDragonData.Level) / 100;
        childDragonData.attack += Random.Range(1, 5);
        return childDragonData.attack;
    }
    int Hp()
    {
       // childDragonData.hp = childDragonData.dafaultHp + (int)(childDragonDataMax.maxHp * childDragonData.Level) / 100;
        childDragonData.hp += Random.Range(1, 5);
        return childDragonData.hp;
    }
}
