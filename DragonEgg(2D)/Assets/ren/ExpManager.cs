using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ExpManager : MonoBehaviour
{
    // エディタでアタッチ
    [SerializeField] public ChildDragonData childDragonData;

    
    int maxExp;//レベルアップに必要な量
    int nowExp;
    int addExp = 30; //加える経験値
    
    public Slider slider;
    // Start is called before the first frame update
    void Start()//逆だとバグる
    {
        maxExp = 100;
        slider.maxValue = maxExp;
        nowExp = childDragonData.exp; //現在の経験値
        slider.value = nowExp;
        
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

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


}
