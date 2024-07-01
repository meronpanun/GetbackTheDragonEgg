using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFryController : Enemy
{
    private const int DRAGONFRYATTACK = 1;

    protected override void Start()
    {
        base.Start();
        attack = DRAGONFRYATTACK;
    }
}