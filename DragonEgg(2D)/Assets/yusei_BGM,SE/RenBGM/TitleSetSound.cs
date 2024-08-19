using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TitleSetSound : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private float setDecibel;
    // Start is called before the first frame update
    void Start()
    {
        //•Û‘¶‚³‚ê‚½‰¹—Ê‚ðƒZƒbƒg‚·‚é
        setDecibel = PlayerPrefs.GetFloat("MasterDecibel", 0f);
        audioMixer.SetFloat("Master_Volume", setDecibel);
        setDecibel = PlayerPrefs.GetFloat("BgmDecibel", 0f);
        audioMixer.SetFloat("BGM_Volume", setDecibel);
        setDecibel = PlayerPrefs.GetFloat("SeDecibel", 0f);
        audioMixer.SetFloat("SE_Volume", setDecibel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
