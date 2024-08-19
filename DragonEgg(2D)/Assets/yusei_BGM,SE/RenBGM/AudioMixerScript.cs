using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    //[SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    // Start is called before the first frame update
    void Start()
    {
        //if (masterSlider != null)
        //{
        //    masterSlider.onValueChanged.AddListener((value) =>
        //    {
        //        value = Mathf.Clamp01(value);

        //        float decibel = 20f * Mathf.Log10(value);
        //        decibel = Mathf.Clamp(decibel, -80f, 0f);
        //        audioMixer.SetFloat("Master_Volume", decibel);
        //    });
        //}
        if (bgmSlider != null)
        {
            bgmSlider.onValueChanged.AddListener((value) =>
            {
                value = Mathf.Clamp01(value);

                float decibel = 20f * Mathf.Log10(value);
                decibel = Mathf.Clamp(decibel, -80f, 0f);
                audioMixer.SetFloat("BGM_Volume", decibel);
            });
        }
        if (seSlider != null)
        {
            seSlider.onValueChanged.AddListener((value) =>
            {
                value = Mathf.Clamp01(value);

                float decibel = 20f * Mathf.Log10(value);
                decibel = Mathf.Clamp(decibel, -80f, 0f);
                audioMixer.SetFloat("SE_Volume", decibel);
            });
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
