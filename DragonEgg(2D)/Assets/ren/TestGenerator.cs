
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGenerator : MonoBehaviour
{
    private const int COLUMN = 2;//行
    private const int ROW = 5;//列
   
    private DragonData dragonData;

    public GameObject ChildDoragonIconPrefab;
    [SerializeField] GameObject childDragonIcon;
    [SerializeField] GameObject canvas;

    private const int SIFTRIGHT = 200;//ずらす距離
    private const int SIFTDOWN = 200;//ずらす距離
    int inputX = 100;
    int inputY = 200;
    RectTransform iconRectTransform;

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
                iconRectTransform = childDragonIcon.GetComponent<RectTransform>();
                childDragonIcon.transform.SetParent(canvas.transform, false);//canvasに格納
                Vector2 pos = iconRectTransform.position;
                pos.x = inputX;
                pos.y = inputY;
                iconRectTransform.position = pos;
                inputX += SIFTRIGHT;
            }
            inputX = 100;
            inputY -= SIFTDOWN;
        }
    }
}
