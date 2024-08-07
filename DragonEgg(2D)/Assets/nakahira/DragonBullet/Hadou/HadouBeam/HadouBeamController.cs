using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouBeamController : PlayerBullet
{
    private const int BEAMATTACK = 5;
    private Vector3 beamExpandSpeed = new Vector3(0, 1, 0);

    private void Awake()
    {
        baseAttack = BEAMATTACK;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // こいつだけ結構特殊なんでbaseは実行してない∃
    protected override void Update()
    {
        // ビーム伸ばす
        if (transform.localScale.y < 12)
        {
            transform.localScale += beamExpandSpeed;
        }

    }
}
