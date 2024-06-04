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
        hitPoint = 100; // なんか
    }

    // 動く関連の処理はORBと同じ

    private void OnDestroy() // 死んだとき、クリア画面へ
    {
        SceneManager.LoadScene("ClearScene"); // OnDestroyではコルーチン使えないんかい
    }

    IEnumerator Clear(float interval)
    {
        yield return new WaitForSeconds(interval);
        SceneManager.LoadScene("ClearScene");
    }
}
