using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//スクリプトでUI(テキストなど)扱うときはこれ必須！！

public class CursorManager : MonoBehaviour
{
    public RectTransform childDragonIcon;//RectTransform型の変数aを宣言　作成したテキストオブジェクトをアタッチしておく
    //アップデート関数
    void Update()
    {
       

        //if (Input.GetKey(KeyCode.UpArrow) && flag != 0 && y <= 0.00f)
        //{
        //    childDragonIcon.position += new Vector3(0.1f, 0, 0);//毎フレームx座標を0.1ずつプラス
        //}
        //else if (Input.GetKey(KeyCode.DownArrow) && flag != 0 && y >= -28.00f)
        //{
        //    childDragonIcon.position += new Vector3(0.1f, 0, 0);//毎フレームx座標を0.1ずつプラス
        //}
    }
}
