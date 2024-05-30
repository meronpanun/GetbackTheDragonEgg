using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // sceneØ‚è‘Ö‚¦‚ğs‚¤‚½‚ß

public class ReturnSelectScene : MonoBehaviour
{
    void Start()
    {
        
    }



    void Update()
    {
        
    }

    public void ReturnStageSelectScene()
    {
        Debug.Log("ReturnStageSelect");
        SceneManager.LoadSceneAsync("TestStageSelectScene");
    }

}
