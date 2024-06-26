using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMonsterBox : MonoBehaviour
{
    public RectTransform moveIcon;
    const float UPPER = 100.00f;//上限
    const float LOWER = 0.00f;//下限
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MonsterBox();
    }
    public void MonsterBox()//カメラがきれいにy=0で止まらない　動作的には問題ないけど気になるから今後修正
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            if (transform.position.y !>= UPPER)
            {
                moveIcon.position += new Vector3(0, 3.0f, 0);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
            //現在の位置からx方向に1移動する

            if (transform.position.y !<= LOWER)
            {
                moveIcon.position += new Vector3(0f, -3.0f, 0f);
            }
        }
    }


}
