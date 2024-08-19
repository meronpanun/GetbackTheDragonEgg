using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private const string kPlayerPrefsKey = "Progress";
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        if (value == 0)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
