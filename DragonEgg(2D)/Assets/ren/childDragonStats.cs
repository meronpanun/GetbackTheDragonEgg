using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDragonStats : MonoBehaviour
{
    [SerializeField] int hp = 100;
    [SerializeField] int attack = 10;
    [SerializeField] float speed = 0.1f;
    [SerializeField] public int exp;
    [SerializeField] public int maxExp;
    [SerializeField] string childDragonName;
    [SerializeField] public int Level;

    [SerializeField] int levelMaxHp = 1000;
    [SerializeField] int levelMaxAttack = 500;

    GameObject FireDragon;
    int useExp;
    int debug1;

    private ChildDragonStats childDragonStats;

    void Start()//逆だとバグる
    {
        FireDragon = GameObject.Find("FireDragon");
        childDragonStats = FireDragon.GetComponent<ChildDragonStats>();
    }
    (int, int) expManager(int getExp) //タプル
    {
        childDragonStats.exp += getExp;
        if (childDragonStats.maxExp <= childDragonStats.exp && Level != 100)
        {
            childDragonStats.exp -= childDragonStats.maxExp;
            childDragonStats.maxExp = (int)(childDragonStats.maxExp * 1.2f);
            Level++;
            childDragonStats.attack = Attack();
            childDragonStats.hp = Hp();
        }
        else if(Level >= 100)
        {
            childDragonStats.maxExp = (int)(childDragonStats.maxExp * 1.2f);
            childDragonStats.exp = childDragonStats.maxExp;
            Level = 100;
            childDragonStats.attack = Attack();
            childDragonStats.hp = Hp();
        }

        return (childDragonStats.exp, childDragonStats.maxExp);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && Level != 100)
        {
            useExp = useExp + 10;
            Debug.Log(useExp);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && Level != 100)
        {
            useExp = useExp - 10;
            Debug.Log(useExp);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Level != 100)
        {
            if (useExp <= 0)
            {
                useExp = 0;
            }
            Debug.Log(expManager(useExp));
            useExp = 0;
        }
    }
    int Attack()
    {
        childDragonStats.attack = (int)(childDragonStats.levelMaxAttack * childDragonStats.Level) / 100;
        return childDragonStats.attack;
    }
    int Hp()
    {
        childDragonStats.hp = (int)(childDragonStats.levelMaxHp * childDragonStats.Level) / 100;
        return childDragonStats.hp;
    }
}
