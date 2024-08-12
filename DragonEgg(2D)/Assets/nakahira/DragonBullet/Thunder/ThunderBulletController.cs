using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletController : PlayerBullet
{
    private bool isStay = true; // Å‰‚Í‘Ò‹@

    protected override void Update()
    {
        // ƒL[‚ğ—£‚µ‚½‚ç
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isStay = false;
        }

        if (isStay)
        {
            // ‚¨‚Æ‚È‚µ‚­‚·‚é
        }
        else
        {
            base.Update(); // ‚¢‚Â‚à‚Ì“®‚«‚ğ‚·‚é
        }
    }

    public void  SetAttack(int attack)
    {
        finalAttack = attack;
    }
}
