using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterValue", 1f);
        bgmSlider.value = PlayerPrefs.GetFloat("BgmValue", 1f);
        seSlider.value = PlayerPrefs.GetFloat("SeValue", 1f);
        if (masterSlider != null)
        {
            masterSlider.onValueChanged.AddListener((value) =>
            {
                value = Mathf.Clamp01(value);

                float decibel = 20f * Mathf.Log10(value);
                decibel = Mathf.Clamp(decibel, -80f, 0f);
                audioMixer.SetFloat("Master_Volume", decibel);
            });
        }
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

    public void OnSaveValue()
    {
        float masterValue = masterSlider.value;
        PlayerPrefs.SetFloat("MasterValue", masterValue);
        float bgmValue = bgmSlider.value;
        PlayerPrefs.SetFloat("BgmValue", bgmValue);
        float seValue = seSlider.value;
        PlayerPrefs.SetFloat("SeValue", seValue);
    }
}
