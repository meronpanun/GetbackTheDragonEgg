using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class EggGeneratorTestTest : MonoBehaviour
{
    public GameObject ChildDoragonPrefab;
    private ChildDragonData childDragonData;
    int x = -86;
    int y = 1;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Eggspawn();
            x += 3;
            if(x >= -71)
            {
                x = -86;
                y -= 3;
            }
        }
    }

    void Eggspawn()
    {
        GameObject childDragon = Instantiate(ChildDoragonPrefab);//インスタンス化
        childDragonData = childDragon.GetComponent<ChildDragonData>();
        childDragonData.hp = IndividualValueGetHp(Random.Range(10, 15));
        childDragonData.attack = IndividualValueGetAttack(Random.Range(1, 5));
        childDragon.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        childDragon.transform.position = new Vector3(x, y, 0);
    }

    int IndividualValueGetHp(int ivNum)//個体値
    {
        childDragonData.hp = ivNum;
        return childDragonData.hp;
    }
    int IndividualValueGetAttack(int ivNum)//個体値
    {
        childDragonData.attack = ivNum;
        return childDragonData.attack;
    }
}
