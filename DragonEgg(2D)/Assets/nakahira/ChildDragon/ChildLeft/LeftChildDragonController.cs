using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DragonRace;

public class LeftChildDragonController : MonoBehaviour
{
    // アニメーションを切り替える

    private races myRace;
    private Animator myAnimator;

    private Image meterImage;
    private Image meterGuageImage;

    // めんどくさいからエディタで付ける
    [SerializeField]
    private Sprite playerMeterSprite;
    [SerializeField]
    private Sprite playerMeterGuageSprite;
    [SerializeField]
    private Sprite fireMeterSprite;
    [SerializeField]
    private Sprite fireMeterGuageSprite;
    [SerializeField]
    private Sprite iceMeterSprite;
    [SerializeField]
    private Sprite iceMeterGuageSprite;
    [SerializeField]
    private Sprite windMeterSprite;
    [SerializeField]
    private Sprite windMeterGuageSprite;
    [SerializeField]
    private Sprite thunderMeterSprite;
    [SerializeField]
    private Sprite thunderMeterGuageSprite;
    [SerializeField]
    private Sprite noneMeterSprite;
    [SerializeField]
    private Sprite noneMeterGuageSprite;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        meterImage = GameObject.Find("LeftChargeMeter").GetComponent<Image>();
        meterGuageImage = GameObject.Find("LeftChargeMeterInside").GetComponent<Image>();
        // 編成から情報を受け取る
        // 仮でバトルチームに適当なデータを入れる
        //BattleTeam.sChildDragonDataLeft = races.wind;
        myRace = BattleTeam.sChildDragonDataLeft;
        //Debug.Log($"種族{myRace}");
        // 自分の種族のゲージに
        // それぞれに対応したアニメーションと、弾を撃てるようにする
        switch (myRace)
        {
            case races.player:
                myAnimator.SetTrigger("Player");
                gameObject.AddComponent<HadouShooter>();
                meterImage.sprite = playerMeterSprite;
                meterGuageImage.sprite = playerMeterGuageSprite;
                break;
            case races.fire:
                myAnimator.SetTrigger("Fire");
                gameObject.AddComponent<FireShooter>();
                meterImage.sprite = fireMeterSprite;
                meterGuageImage.sprite = fireMeterGuageSprite;
                break;
            case races.ice:
                myAnimator.SetTrigger("Ice");
                gameObject.AddComponent<IceShooter>();
                meterImage.sprite = iceMeterSprite;
                meterGuageImage.sprite = iceMeterGuageSprite;
                break;
            case races.wind:
                myAnimator.SetTrigger("Wind");
                gameObject.AddComponent<WindShooter>();
                meterImage.sprite = windMeterSprite;
                meterGuageImage.sprite = windMeterGuageSprite;
                break;
            case races.thunder:
                myAnimator.SetTrigger("Thunder");
                gameObject.AddComponent<ThunderShooter>();
                meterImage.sprite = thunderMeterSprite;
                meterGuageImage.sprite = thunderMeterGuageSprite;
                break;
            case races.none:
                myAnimator.SetTrigger("Empty");
                meterImage.sprite = noneMeterSprite;
                meterGuageImage.sprite = noneMeterGuageSprite;
                break;
            default:
                myAnimator.SetTrigger("Error");
                Debug.Log("Error!!");
                break;
        }
    }
}
