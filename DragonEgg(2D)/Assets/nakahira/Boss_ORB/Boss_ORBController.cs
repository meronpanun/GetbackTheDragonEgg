using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_ORBController : ORBController // 継承
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 100;
        shootSpan = 0.3f;
        attack = 5;
    }

    // 動く関連の処理はORBと同じ

    private void OnDestroy() // 死んだとき、クリア画面へ
    {
        SceneManager.LoadScene("ClearScene"); // OnDestroyではコルーチン使えないんかい
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canMove = false; // 親のORBスクリプトでcanShootもfalseにしてます。
    }
}
