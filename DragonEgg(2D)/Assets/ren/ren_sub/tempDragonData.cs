using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempDragonData : MonoBehaviour
{
    //変数名が他のスクリプトと被ってバグりそうなので一旦myつける
    private int myHp;
    private int myAttack;
    private int myLevel;

    //0 = hp
    //1 = attack
    //2 = level
    private int[,] myCharacter = new int[10,3];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i <  10;i++)
        {
            for (int j = 0; j < 3; j++)
            {
                myHp = 10;
                myAttack = 10;
                myLevel = 1;
                
                switch (j)
                { 
                    case 0:
                        myCharacter[i, j] = myHp;
                        continue;
                    case 1:
                        myCharacter[i, j] = myAttack;
                        continue;
                    case 2:
                        myCharacter[i, j] = myLevel;
                        continue;
                }
                //NowStatus(myCharacter[i, j]);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NowStatus(int[,] chara,int i)
    {
        chara[i, 0] = chara[i, 0] + chara[i, 2] * 2;
        chara[i, 1] = chara[i, 1] + chara[i, 2] * 2;
    }
}
