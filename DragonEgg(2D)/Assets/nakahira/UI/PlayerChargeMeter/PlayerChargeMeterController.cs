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

    public IEnumerator ReduceMeter(float time) // time•b‚©‚¯‚Ä‘S•”‚ÌƒQ[ƒW‚ªŒ¸‚é
    {
        if (time == 0) // 0‚ÅŠ„‚é‚Ì‚ð–h‚¬‚Ü‚·
        {
            image.fillAmount = 0;
            yield break;
        }

        // ‚â‚Á‚Ï‚èŠ|‚¯ŽZ‚É‚µ‚Æ‚¢‚½‚Ù‚¤‚ª‚¢‚¢‚©‚È‚ ‚Á‚Ä
        float factor = 1 / time;

        while (image.fillAmount > 0)
        {
            image.fillAmount -= factor * Time.deltaTime;
            yield return null;
        }
    }
}
