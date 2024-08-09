using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // sceneØ‚è‘Ö‚¦‚ðs‚¤‚½‚ß
using TMPro;

public class CreditScript : MonoBehaviour
{
    private GameObject button;
    private bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button");
        button.SetActive(false);
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.transform.position.y > 1000)
        {
            isEnd = true;
            button.SetActive(true);
        }

        if (!isEnd)
        {
            this.transform.position += new Vector3(0, 0.05f, 0);
        }
       
    }

    public void OnSceneMove()
    {
        SceneManager.LoadScene("optionScene");
    }
}
