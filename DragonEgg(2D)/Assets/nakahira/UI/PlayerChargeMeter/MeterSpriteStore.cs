using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MeterSpriteStore")]
public class MeterSpriteStore : ScriptableObject
{
    public Sprite playerMeterSprite;
    public Sprite playerMeterGuageSprite;
    public Sprite fireMeterSprite;
    public Sprite fireMeterGuageSprite;
    public Sprite iceMeterSprite;
    public Sprite iceMeterGuageSprite;
    public Sprite windMeterSprite;
    public Sprite windMeterGuageSprite;
    public Sprite thunderMeterSprite;
    public Sprite thunderMeterGuageSprite;
    public Sprite noneMeterSprite;
    public Sprite noneMeterGuageSprite;
}
