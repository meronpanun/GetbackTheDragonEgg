using DragonRace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChargeMeterController : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void FillMeter(float value)
    {
        image.fillAmount = value;
    }

    public IEnumerator ReduceMeter(float time) // time秒かけて全部のゲージが減る
    {
        if (time == 0) // 0で割るのを防ぎます
        {
            image.fillAmount = 0;
            yield break;
        }

        // やっぱり掛け算にしといたほうがいいかなあって
        float factor = 1 / time;

        while (image.fillAmount > 0)
        {
            image.fillAmount -= factor * Time.deltaTime;
            yield return null;
        }
    }
}
