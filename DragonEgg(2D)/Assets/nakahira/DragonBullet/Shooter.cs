using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    protected bool canShoot = true; // 弾撃てるかどうか

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
