
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerator : MonoBehaviour
{
    private const int COLUMN = 2;//行
    private const int ROW = 5;//列
   
    private DragonData dragonData;

    public GameObject ChildDoragonIconPrefab;
    [SerializeField] GameObject childDragonIcon;
    [SerializeField] GameObject canvas;

    private const int SIFTRIGHT = 3;//ずらす距離
    private const int SIFTDOWN = 2;//ずらす距離
    int x = -246;
    int y = -1;
    // Start is called before the first frame update
    void Start()
    {
        dragonData = new DragonData();
        dragonData.LoadAllDragonData();
        PrepareDragonButtun();
    }

    // Update is called once per frame
    private void PrepareDragonButtun()
    {
        for(int i = 0;i < COLUMN;i++)
        {
            for (int j = 0; j < ROW; j++) 
            {
                GameObject childDragonIcon = Instantiate(ChildDoragonIconPrefab);//インスタンス化
                childDragonIcon.transform.parent = canvas.transform;
                childDragonIcon.transform.localScale = new Vector3(0.02f, 0.02f, 1);
                childDragonIcon.transform.position = new Vector3(x, y, 0);
                x += SIFTRIGHT;
            }
            x = -246;
            y -= SIFTDOWN;
        }
    }
}
