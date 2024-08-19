using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    int value;
    public GameObject title;
    FadeManager fadeManager;
    public int savedate;
    // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnClickContinue()
    {
        value = PlayerPrefs.GetInt("Progress");

        // セーブデータがなかったら押せない
        if (value == 0)
        {
            return;

        }
        else
        {
            fadeManager.FadeOutSwitch(100);
        }
    }
}
