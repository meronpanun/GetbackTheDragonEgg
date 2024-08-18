using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        AudioSource temp = GetComponent<AudioSource>();
        temp.Play();
        while (temp.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
