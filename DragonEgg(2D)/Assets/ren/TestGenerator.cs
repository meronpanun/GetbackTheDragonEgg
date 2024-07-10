
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGenerator : MonoBehaviour
{
    private const int COLUMN = 2;//行
    private const int ROW = 5;//列
   
    private DragonDataManager dragonDataClass;

    public GameObject ChildDoragonIconPrefab;
    [SerializeField] GameObject childDragonIcon;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject parent;

    private const int SIFTRIGHT = 200;//ずらす距離
    private const int SIFTDOWN = 100;//ずらす距離
    int inputX = 300;
    int inputY = 200;
    int count = 0;
    RectTransform iconRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        dragonDataClass = DragonDataManagerGenerater.dragonData;
        //PrepareDragonButtun();
    }

    // Update is called once per frame
    public void PrepareDragonButtun()
    {
        for(int i = 0;i < COLUMN;i++)
        {
            for (int j = 0; j < ROW; j++) 
            {
                GameObject childDragonIcon = Instantiate(ChildDoragonIconPrefab, parent.transform);//インスタンス化
                childDragonIcon.GetComponent<DragonIconData>().dragonStatus = dragonDataClass.dragonData[count];
                iconRectTransform = childDragonIcon.GetComponent<RectTransform>();
                Vector2 pos = iconRectTransform.position;
                pos.x = inputX;
                pos.y = inputY;
                iconRectTransform.position = pos;
                inputX += SIFTRIGHT;
                count++;
            }
            inputX = 300;
            inputY -= SIFTDOWN;
        }
    }
}
