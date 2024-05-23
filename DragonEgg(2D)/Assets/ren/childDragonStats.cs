using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childDragonStats : MonoBehaviour
{
    [SerializeField] int hp = 100;
    [SerializeField] int attack = 10;
    [SerializeField] float speed = 0.1f;
    [SerializeField] public int exp;
    [SerializeField] public int maxExp;
    [SerializeField] string childDragonName;

    GameObject FireDragon;
    int useExp;
    int debug1;

    void Start()//逆だとバグる
    {
        FireDragon = GameObject.Find("FireDragon");
    }
    (int,int) expManager(int getExp) //タプル
    {
        FireDragon.GetComponent<childDragonStats>().exp += getExp;
        if(FireDragon.GetComponent<childDragonStats>().maxExp <= FireDragon.GetComponent<childDragonStats>().exp)
        {
            FireDragon.GetComponent<childDragonStats>().exp -= FireDragon.GetComponent<childDragonStats>().maxExp;
            FireDragon.GetComponent<childDragonStats>().maxExp = (int)(FireDragon.GetComponent<childDragonStats>().maxExp * 1.2f); 
        }
        
        return (FireDragon.GetComponent<childDragonStats>().exp, FireDragon.GetComponent<childDragonStats>().maxExp);
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            useExp = useExp + 10;
            Debug.Log(useExp);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            useExp = useExp - 10;
            Debug.Log(useExp);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(useExp <= 0)
            {
                useExp = 0;
            }
            Debug.Log(expManager(useExp));
            useExp = 0;
        }
    }

}
