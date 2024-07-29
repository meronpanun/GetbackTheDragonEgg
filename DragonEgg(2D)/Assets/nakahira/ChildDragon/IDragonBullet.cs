using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ドラゴンの弾のインターフェース
// やっぱりインターフェースの存在意義がよくわからん
// インターフェースを継承したクラスをインターフェースの変数にぶち込むとなんかいいことがあるのはなんとなくわかった

// このインターフェースを継承したMonobehaviourスクリプトを
// Start時にAddComponentすればいけるか！？
public interface IDragonBullet
{
    // スペースキーを押したときに実行されるふるまい
    // もっと細かく強制したほうがいいか
    public void GetKeyDownBehaviour(int attack);

    public void GetKeyBehaviour(int attack);

    public void GetKeyUpBehaviour(int attack);
}
