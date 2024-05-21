using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ExpManager : MonoBehaviour
{
    int maxExp;//レベルアップに必要な量
    int nowExp;      //現在の経験値
    int addExp = 30; //加える経験値
    public ChildDragonData childDragonData;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        maxExp = 100;
        slider.maxValue = maxExp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowScriptableObjectData();
            nowExp += addExp;//経験値を加える
            slider.value = (float)nowExp;
        }

        if (maxExp <= nowExp)//レベルアップしたとき次のレベルアップに必要な量を更新
        {
            nowExp = nowExp - maxExp;
            slider.value = nowExp;
            maxExp += 100;
            slider.maxValue = maxExp;
        }
    }

    void ShowScriptableObjectData()
    {
        // 参照しているEnemyDataの中身をコンソールに表示する
        Debug.Log(childDragonData.Exp);
    }
}
