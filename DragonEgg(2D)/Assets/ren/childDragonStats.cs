using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDragonStats : MonoBehaviour
{
    //[SerializeField] int hp = 100;
    //[SerializeField] int attack = 10;
    //[SerializeField] float speed = 0.1f;
    //[SerializeField] public int exp;
    //[SerializeField] public int maxExp;
    //[SerializeField] string childDragonName;
    //[SerializeField] public int Level;

    //[SerializeField] int levelMaxHp = 1000;
    //[SerializeField] int levelMaxAttack = 500;

//    GameObject FireDragon;
//    int useExp;
//    int debug1;
    
//    private ChildDragonData childDragonData;
//    private ChildDragonData_Max childDragonDataMax;

//    void Start()//逆だとバグる
//    {
//        FireDragon = GameObject.Find("FireDragon");
//        childDragonData = FireDragon.GetComponent<ChildDragonData>();
//        childDragonDataMax = FireDragon.GetComponent<ChildDragonData_Max>();
       

//    }
//    (int, int) expManager(int getExp) //タプル
//    {
//        childDragonData.exp += getExp;
//        if (childDragonData.maxExp <= childDragonData.exp && childDragonData.Level != 100)
//        {
//            childDragonData.exp -= childDragonData.maxExp;
//            childDragonData.maxExp = (int)(childDragonData.maxExp * 1.2f);
//            childDragonData.Level++;
//            childDragonData.attack = Attack();
//            childDragonData.hp = Hp();
//        }
//        else if(childDragonData.Level >= 100)
//        {
//            childDragonData.maxExp = (int)(childDragonData.maxExp * 1.2f);
//            childDragonData.exp = childDragonData.maxExp;
//            childDragonData.Level = 100;
//            childDragonData.attack = Attack();
//            childDragonData.hp = Hp();
//        }

//        return (childDragonData.exp, childDragonData.maxExp);
//    }
//    void Update()
//    {

//        if (Input.GetKeyDown(KeyCode.RightArrow) && childDragonData.Level != 100)
//        {
//            useExp = useExp + 10;
//            Debug.Log(useExp);
//        }
//        else if (Input.GetKeyDown(KeyCode.LeftArrow) && childDragonData.Level != 100)
//        {
//            useExp = useExp - 10;
//            Debug.Log(useExp);
//        }

//        if (Input.GetKeyDown(KeyCode.Space) && childDragonData.Level != 100)
//        {
//            if (useExp <= 0)
//            {
//                useExp = 0;
//            }
//            Debug.Log(expManager(useExp));
//            useExp = 0;
//        }
//    }
//    int Attack()
//    {
//        childDragonData.attack = (int)(childDragonDataMax.maxAttack * childDragonData.Level) / 100;
//        return childDragonData.attack;
//    }
//    int Hp()
//    {
//        childDragonData.hp = (int)(childDragonDataMax.maxHp * childDragonData.Level) / 100;
//        return childDragonData.hp;
//    }
//}
