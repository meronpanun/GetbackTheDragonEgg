using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_ORBController : ORBController // 継承
{
    private FadeManager fadeManager;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 100;
        shootSpan = 0.3f;
        attack = 5;
        fadeManager = GameObject.Find("FadePanel").GetComponent<FadeManager>();
    }

    // 動く関連の処理はORBと同じ

    protected override void OnDeath()
    {
        base.OnDeath();
        canMove = false; // 親のORBスクリプトでcanShootもfalseにしてます。
    }

    public void LoadClearScene(int value)
    {
        fadeManager.FadeOutSwitch(value);
    }
}
