using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : PlayerBullet
{
    private float RAPIDFIREATTACK = 3f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bulletSpeedy = 10f; // ’e‘¬B“®‚­‘¬‚³
        bulletSpeedx = 0;
        attack = RAPIDFIREATTACK;
    }

    // Update is called once per frame
    protected override void Update() // ¶‚Ü‚ê‚½‚çˆê’¼ü‚Éc•ûŒü‚ÉˆÚ“®‚·‚é
    {
        base .Update();
    }
}
