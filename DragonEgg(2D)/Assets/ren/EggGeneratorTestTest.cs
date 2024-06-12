using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class EggGeneratorTestTest : MonoBehaviour
{
    public GameObject ChildDoragonIconPrefab;
    [SerializeField] GameObject childDragonIcon;
    int x = -86;
    int y = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Eggspawn();
            x += 3;
            if (x >= -71)
            {
                x = -86;
                y -= 3;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Eggspawn()
    {
        GameObject childDragonIcon = Instantiate(ChildDoragonIconPrefab);//インスタンス化
        //ChildDragonData ChildDragonData = ScriptableObject.CreateInstance<ChildDragonData>();
        //childDragonData = ScriptableObject.Instantiate(Resources.Load("EnemyDataTable")) as childDragonData;
        //childDragonIcon = childDragonIcon.GetComponent<ChildDragonData>();
        //childDragonData.hp = IndividualValueGetHp(Random.Range(10, 15));
        //childDragonData.attack = IndividualValueGetAttack(Random.Range(1, 5));
        childDragonIcon.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        childDragonIcon.transform.position = new Vector3(x, y, 0);
    }

    //int IndividualValueGetHp(int ivNum)//個体値
    //{
    //    childDragonData.hp = ivNum;
    //    return childDragonData.hp;
    //}
    //int IndividualValueGetAttack(int ivNum)//個体値
    //{
    //    childDragonData.attack = ivNum;
    //    return childDragonData.attack;
    //}
}
