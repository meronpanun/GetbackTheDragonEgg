using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : PlayerBullet
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bulletSpeedy = 10f; // ’e‘¬B“®‚­‘¬‚³
        bulletSpeedx = 0;
        //if (Random.Range(0,1) == 0)
        //{
        //}
    }

    // Update is called once per frame
    protected override void Update() // ¶‚Ü‚ê‚½‚çˆê’¼ü‚Éc•ûŒü‚ÉˆÚ“®‚·‚é
    {
        base .Update();
    }
}
