using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    private static GameObject SE;

    private void Start()
    {
        SE = (GameObject)Resources.Load("SE");
    }

    // AudioSource.PlayClipAtPointが低機能なので自分で作る
    public static void InstantiateSE(
        AudioClip clip
        )
    {
        // 生成して音を付ける
        GameObject source = Instantiate(SE);
        source.GetComponent<AudioSource>().clip = clip;
    }
}
