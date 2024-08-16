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

    private MeterSpriteStore sprites;

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
        // ScriptableObjectを取得
        sprites = (MeterSpriteStore)Resources.Load("MeterSprites");
        // 自分の種族のゲージに
        // それぞれに対応したアニメーションと、弾を撃てるようにする
        switch (myRace)
        {
            case races.player:
                myAnimator.SetTrigger("Player");
                gameObject.AddComponent<HadouShooter>();
                meterImage.sprite = sprites.playerMeterSprite;
                meterGuageImage.sprite = sprites.playerMeterGuageSprite;
                break;
            case races.fire:
                myAnimator.SetTrigger("Fire");
                gameObject.AddComponent<FireShooter>();
                meterImage.sprite = sprites.fireMeterSprite;
                meterGuageImage.sprite = sprites.fireMeterGuageSprite;
                break;
            case races.ice:
                myAnimator.SetTrigger("Ice");
                gameObject.AddComponent<IceShooter>();
                meterImage.sprite = sprites.iceMeterSprite;
                meterGuageImage.sprite = sprites.iceMeterGuageSprite;
                break;
            case races.wind:
                myAnimator.SetTrigger("Wind");
                gameObject.AddComponent<WindShooter>();
                meterImage.sprite = sprites.windMeterSprite;
                meterGuageImage.sprite = sprites.windMeterGuageSprite;
                break;
            case races.thunder:
                myAnimator.SetTrigger("Thunder");
                gameObject.AddComponent<ThunderShooter>();
                meterImage.sprite = sprites.thunderMeterSprite;
                meterGuageImage.sprite = sprites.thunderMeterGuageSprite;
                break;
            case races.none:
                myAnimator.SetTrigger("Empty");
                meterImage.sprite = sprites.noneMeterSprite;
                meterGuageImage.sprite = sprites.noneMeterGuageSprite;
                break;
            default:
                myAnimator.SetTrigger("Error");
                Debug.Log("Error!!");
                break;
        }
    }
}
