using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSceneManager : MonoBehaviour
{
    StageLoadSceneData stageLoadSceneData;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sceneName);
    }


    public void SceneChangeButton()
    {
        sceneName = StageLoadSceneData.stageLoadScene;
        SceneManager.LoadSceneAsync(sceneName);
    }
}
