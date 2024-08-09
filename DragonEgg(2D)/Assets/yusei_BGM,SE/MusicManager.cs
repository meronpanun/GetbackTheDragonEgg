using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    bool Audio;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        Audio = false;
        // Conponent‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Audio && cam.transform.position.y >25)
        {
            audioSource.PlayOneShot(sound1);
            Audio = true;
        }
    }
}
