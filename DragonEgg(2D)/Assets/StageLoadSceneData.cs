using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageLoadSceneData : MonoBehaviour
{
    public static string stageLoadScene = "TestErrorScene";  // ステージのロードするシーンの名前
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
