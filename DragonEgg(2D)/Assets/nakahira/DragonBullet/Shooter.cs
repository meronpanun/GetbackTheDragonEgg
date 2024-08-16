using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    protected bool canShoot = true; // ’eŒ‚‚Ä‚é‚©‚Ç‚¤‚©

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
