using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPanelManeger : MonoBehaviour
{
    [SerializeField] private GameObject soundPanel;
    // Start is called before the first frame update
    void Start()
    {
        soundPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSoundPanel()
    {
        soundPanel.SetActive(true);
    }

    public void OffSoundPanel()
    {
        soundPanel.SetActive(false);
    }
}
