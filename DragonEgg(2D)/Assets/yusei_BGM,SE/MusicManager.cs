using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSourse;

    Transform cam;

    bool playFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを取得
        audioSourse = GetComponent<AudioSource>();

        cam = GameObject.Find("Main Camera").GetComponent<Transform>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.y > 24 && !playFlag)
        {
            audioSourse.PlayOneShot(sound1);
            playFlag = true;
        }
    }
}
