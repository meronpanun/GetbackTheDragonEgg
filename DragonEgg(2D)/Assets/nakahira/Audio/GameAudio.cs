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

    // AudioSource.PlayClipAtPoint‚ª’á‹@”\‚È‚Ì‚Å©•ª‚Åì‚é
    public static void InstantiateSE(
        AudioClip clip
        )
    {
        // ¶¬‚µ‚Ä‰¹‚ğ•t‚¯‚é
        GameObject source = Instantiate(SE);
        source.GetComponent<AudioSource>().clip = clip;
    }
}
