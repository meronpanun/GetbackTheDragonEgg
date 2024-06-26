
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGenerator : MonoBehaviour
{
    private const int COLUMN = 2;//行
    private const int ROW = 5;//列
   
    private DragonData dragonDataClass;

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
        dragonDataClass = new DragonData();
        dragonDataClass.LoadAllDragonData();
        PrepareDragonButtun();
    }

    // Update is called once per frame
    private void PrepareDragonButtun()
    {
        for(int i = 0;i < COLUMN;i++)
        {
            for (int j = 0; j < ROW; j++) 
            {
                GameObject childDragonIcon = Instantiate(ChildDoragonIconPrefab, parent.transform);//インスタンス化
                childDragonIcon.GetComponent<DragonIconData>().dragonStatus = new TestDragonStatus("1,3,4,5,6,7,8");/*dragonDataClass.dragonData[count];*/
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
