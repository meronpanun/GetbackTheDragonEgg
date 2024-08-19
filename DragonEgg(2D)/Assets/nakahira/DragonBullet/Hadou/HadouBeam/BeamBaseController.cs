using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ビーム部分はtransformのlocalScaleをいじって変形しています。
// これによるビームの基底部分の変形を回避するために
// スプライトやスクリプトを分割する必要があったんですね。　
public class BeamBaseController : MonoBehaviour
{
    private Vector3 beamOffset = new Vector3(0, 0.5f, 0);

    private float beamLifeSpan = 2; // ビームの寿命

    public GameObject myParent; // 追尾先 HadouShooterから直接もらっちゃおう

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの口元に追尾する
        // プレイヤーの子オブジェクトにすると
        // コライダー関連で不都合が出るため
        transform.position = myParent.transform.position + beamOffset;

        // 一定時間たったら消したい
        if (beamLifeSpan < 0)
        {
            Destroy(gameObject);
        }

        beamLifeSpan -= Time.deltaTime; // タイマー減算
    }
}
